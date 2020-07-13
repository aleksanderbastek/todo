function showHelp() {
	Write-Host "Usage: ./restore <PROJECT>`nAvailable projects: frontend, backend, all.`nExample: ./restore all"
}

function restoreFrontend() {
	Write-Host "`nInstalling npm packages of TodoApp.Client`n"

	$cwd = Join-Path $PSScriptRoot "../frontend" | Resolve-Path
	$restoreResult = Start-Process -FilePath npm -ArgumentList install -NoNewWindow -Wait -PassThru -WorkingDirectory $cwd

	if ($restoreResult.ExitCode -ne 0) {
		Write-Host "`nNpm packages restore error with code $($restoreResult.ExitCode)"
		exit 1
	}
	else {
		$runTime = $restoreResult.ExitTime - $restoreResult.StartTime
		Write-Host "`nNpm packages restore complete in $runTime"
	}
}

function restoreBackend() {
	Write-Host "`nRestoring dotnet packages of TodoApp.Server`n"

	$cwd = Join-Path $PSScriptRoot "../backend" | Resolve-Path
	$restoreResult = Start-Process -FilePath dotnet -ArgumentList restore, TodoApp.Server/TodoApp.Server.csproj -NoNewWindow -Wait -PassThru -WorkingDirectory $cwd

	if ($restoreResult.ExitCode -ne 0) {
		Write-Host "Dotnet packages restore error with code $($restoreResult.ExitCode)"
		exit 1
	}
	else {
		$runTime = $restoreResult.ExitTime - $restoreResult.StartTime
		Write-Host "`nDotnet packages restore done in $runTime"
	}
}

function restoreAllProjects() {
	restoreFrontend
	restoreBackend
}

function executeCommand($command) {
	switch ($command) {
		frontend { restoreFrontend }
		backend { restoreBackend }
		all { restoreAllProjects }

		-help { showHelp }
		-h { showHelp }

		Default {
			Write-Host "`"$command`" is not vaild type of project to restore."
			showHelp
			exit 1
		}
	}
}

$command = $args[0]

if (@("frontend", "backend", "all") -contains $command) {
	$runTime = [System.Diagnostics.Stopwatch]::StartNew();

	Write-Host "Restoring $command packages"
	executeCommand($command)
	Write-Host "Restore done in $($runTime.Elapsed)"
}
else {
	executeCommand $command
}

