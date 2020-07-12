function ContainsFileWithExtension ($dir, $ext) {
	$filesWithSpecifiedExtension = Get-ChildItem -File -Path $dir | Where-Object Extension -eq $ext
	return $filesWithSpecifiedExtension.Length -gt 0
}

function ContainsFile ($dir, $fileName) {
	$files = Get-ChildItem -Path $dir -File | Select-Object -ExpandProperty Name
	return $files -ccontains $fileName
}

function ContainsDirectory ($from, $expected) {
	$dirs = Get-ChildItem -Directory -Path $from
	return $dirs -contains $expected
}

function ContainsCsprojFile ($dir) {
	return ContainsFileWithExtension $dir ".csproj"
}

function ContainsNpmProject ($dir) {
	return ContainsFile $dir "package.json"
}

function FindEveryDirectory ($inside, $searchFor, $exclude, $checkScript, $result) {
	if ($null -eq $result) {
		$result = @()

		if (& $checkScript $inside) {
			$contents = Get-ChildItem $inside -Directory

			foreach ($dir in $contents) {
				if ($searchFor -ccontains $dir.Name) {
					$dirPath = Join-Path $inside $dir.Name | Resolve-Path
					$result += $dirPath
				}
			}

			return $result
		}
	}

	$dirs = Get-ChildItem $inside -Directory -Exclude $exclude

	foreach ($subdir in $dirs) {
		if (& $checkScript $subdir.FullName) {
			$subdirContents = Get-ChildItem $subdir -Directory

			foreach ($dir in $subdirContents) {
				if ($searchFor -ccontains $dir.Name) {
					$dirPath = Join-Path $subdir.FullName $dir.Name | Resolve-Path
					$result += $dirPath
				}
			}

			continue
		}

		if ($exclude -cnotcontains $subdir.Name) {
			$result = FindEveryDirectory -inside $subdir.FullName -searchFor $searchFor -exclude $exclude -checkScript $checkScript -result $result
		}
	}

	return $result
}

function PrintNameAndDeleteDir ($dir) {
	Write-Host $dir
	Remove-item $dir -Force -Recurse
}

function CleanupFor($command) {
	switch ($command) {
		frontend {
			Write-Host "`nPerforming cleanup on the frontend project:`n"

			$frontendRoot = (Join-Path $PSScriptRoot "../frontend" | Resolve-Path).Path
			$result = FindEveryDirectory -inside $frontendRoot -searchFor node_modules, dist -exclude node_modules, ".vscode", dist -checkScript { param ($dir) ContainsNpmProject $dir }
			$result | ForEach-Object -Process { PrintNameAndDeleteDir $_ }

			Write-Host "`nFrontend project cleanup done!`n"
		}

		backend {
			Write-Host "`nPerforming cleanup on the backend projects:`n"

			$backendRoot = Join-Path $PSScriptRoot "../backend" | Resolve-Path
			$result = FindEveryDirectory -inside $backendRoot -searchFor obj, bin -exclude node_modules, ".vscode" -checkScript { param ($dir) ContainsCsprojFile $dir }
			$result | ForEach-Object -Process { PrintNameAndDeleteDir $_ }

			Write-Host "`nBackend projects cleanup done!`n"
		}

		nginx-certs {
			Write-Host "`nPerforming cleanup on the nginx proxy certificates`n"

			Join-Path $PSScriptRoot "../nginx/certs" | Remove-Item -Force -Recurse

			Write-Host "`nNginx proxy certs cleanup done!`n"
		}

		all {
			CleanupFor frontend
			CleanupFor backend
			CleanupFor nginx-certs
		}

		Default {
			Write-Host "`nProject `"$command`" is not supported, available options are: `n  - frontend `n`  - backend `n`  - nginx-certs `n`  - all `n"
			exit 1
		}
	}
}

if ($args -contains "-h" -or $args -contains "-help") {
	Write-Host "`nUsage: pwsh ./cleanup.ps1 <PROJECTS>, you can use multiple projects at one run, available projects are: `n  - frontend `n`  - backend `n`  - nginx-certs `n`  - all `n"
	exit 0
}

if ($args -contains "all") {
	CleanupFor all
	exit 0
}

foreach ($command in $args) {
	CleanupFor $command
}
