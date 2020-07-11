Import-Module $PSScriptRoot/helpers/Invoke-DevDockerCompose -Function Invoke-DevDockerCompose

Write-Host "`nBuilding development environment`n"

$buildResult = Invoke-DevDockerCompose build

if ($buildResult.ExitCode -eq 0) {
	$totalExecutionTime = $buildResult.ExitTime - $buildResult.StartTime
	Write-Host "`nDevelopment environment build completed in $($totalExecutionTime)`n"
}
else {
	Write-Host "`nDevelopment environment build error (code: $($buildResult.ExitCode))`n"
	exit 1
}
