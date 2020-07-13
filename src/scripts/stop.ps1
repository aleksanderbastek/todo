Import-Module $PSScriptRoot/helpers/Invoke-DevDockerCompose -Function Invoke-DevDockerCompose

Write-Host "`nStopping development environment...`n"
$result = Invoke-DevDockerCompose stop

if ($result.ExitCode -eq 0) {
	$runTime = $result.ExitTime - $result.StartTime
	Write-Host "`nDevelopment environment stopped in $runTime`n"
}
else {
	Write-Host "`nDevelopment environment stop error with code $($result.ExitCode)"
	exit 1
}
