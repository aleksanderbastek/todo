$devComposeFiles = @("docker-compose.yml", "docker-compose.dev.yml")

function buildDockerComposeFilesArray() {
	$listOfFiles = @()

	foreach ($file in $devComposeFiles) {
		$listOfFiles += "-f"
		$listOfFiles += $file
	}

	return $listOfFiles
}

function Invoke-DevDockerCompose($command) {
	$files = buildDockerComposeFilesArray
	$filesAndCommand = $files + @($command)

	$cwd = Join-Path $PSScriptRoot "../.." | Resolve-Path
	$result = Start-Process -FilePath docker-compose -ArgumentList $filesAndCommand -PassThru -Wait -NoNewWindow -WorkingDirectory $cwd

	return $result
}

Export-ModuleMember -Function Invoke-DevDockerCompose
