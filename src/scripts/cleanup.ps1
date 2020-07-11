function ContainsFileWithExtension ($dir, $ext) {
	$filesWithSpecifiedExtension = Get-ChildItem -File -Path $dir | Where-Object Extension -eq $ext
	return $filesWithSpecifiedExtension.Length -gt 0
}

function ContainsDirectory ($from, $expected) {
	$dirs = Get-ChildItem -Directory -Path $from
	return $dirs -contains $expected
}

function ContainsDirectories ($from, $expected) {
	foreach ($dir in $expected) {
		if (ContainsDirectory $from $dir -eq $false) {
			return $false
		}
	}

	return $true
}

function ContainsCsprojFile ($dir) {
	return ContainsFileWithExtension $dir ".csproj"
}

function ContainsDotnetRestoreArtifacts ($dir) {
	return ContainsDirectory $dir "obj"
}

function ContainsDotnetBuildArtifacts ($dir) {
	return ContainsDirectory $dir "bin"
}

function FindEveryDirectoryExcluding ($include, $searchFor, $exclude, $result) {
	if ($null -eq $result) {
		$result = @()
	}

	$dirs = Get-ChildItem $include -Directory -Exclude $exclude

	foreach ($subdir in $dirs) {
		if (ContainsCsprojFile $subdir.FullName -and $searchFor -contains $subdir) {
			$dirPath = Join-Path $subdir.FullName $expected
			$result.Add($dirPath)
			continue
		}

		FindEveryDirectoryExcluding $subdir.FullName $searchFor $exclude $result
	}
}

function CleanupDotnetBuildArtifacts ($dir) {
	if (ContainsDotnetBuildArtifacts $dir) {
		Remove-Item $dir -Force
	}
}

$command = $args[0]

switch ($command) {
	frontend {}
	backend {}
	all {}
	-help {}
	Default {}
}
