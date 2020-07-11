Import-Module $PSScriptRoot/helpers/Invoke-DevDockerCompose -Function Invoke-DevDockerCompose

Write-Host "`nStarting development environment up`n"
$startupResult = Invoke-DevDockerCompose up, --remove-orphans, --detach

if ($startupResult.ExitCode -eq 0) {
	$runTime = $startupResult.ExitTime - $startupResult.StartTime
	Write-Host "`nDevelopment environment started in background in $runTime`n"
}
else {
	Write-Host "`nDevelopment environment startup error with code $($startupResult.ExitCode)`n"
	exit 1
}
