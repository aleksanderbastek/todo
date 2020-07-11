Import-Module $PSScriptRoot/helpers/Invoke-DevDockerCompose -Function Invoke-DevDockerCompose

if (@("-h", "-help") -contains $args[0]) {
	Write-Host "Removes all development containers and networks. If you want to also remove volumes use -Full switch."
}

Write-Host "`nStarting development environment prune`n"
$result = Invoke-DevDockerCompose down --volumes

if ($result.ExitCode -eq 0) {
	if ($args[0] -eq "-Full") {
		Write-Host "`nRemoving volumes:`n"

		docker volume rm Dev.TodoApp.Database -f
		docker volume rm Dev.TodoApp.PgAdmin -f

		Write-Host "`nVolumes removed"
	}

	$runTime = $result.ExitTime - $result.StartTime
	Write-Host "`nDevelopment environment prune done in $runTime`n"
}
else {
	Write-Host "`nDevelopment environment prune error with code $($result.ExitCode)"
	exit 1
}
