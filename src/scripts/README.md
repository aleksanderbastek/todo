# Common scripts:

There are available some helpful scripts that are also available as VS Code tasks.

## Prerequisites:

-   Powershell Core 7
-   Docker and Docker-compose
-   Node.js and npm
-   Dotnet Core 3.1
-   Visual Studio Code

## Quick first run

At first, run make sure you have all the required software installed. Then run commands in the following way:

-   `restore all` using VS Code task `Restore: all` or `pwsh ./src/scripts/restore.ps1 all` command in terminal
-   `build` using VS Code task `Build: docker images` or `pwsh ./src/scripts/build.ps1` command in terminal
-   `start` using VS Code task `Start: development environment` or `pwsh ./src/scripts/start.ps1`

## Available scripts:

-   `restore`

    Restores npm or dotnet core packages.<br/>
    Usage: `pwsh restore.ps1 <PROJECT>`.<br/>
    Where `<PROJECT>` can be: `frontend` / `backend` / `all`.<br/>
    Example usage: `pwsh restore.ps1 frontend`

-   `build`

    Builds docker-compose environment.<br/>
    Equivalent for `docker-compose build`.<br/>
    Usage: `pwsh build.ps1`.

-   `start`

    Starts development environment up.<br/>
    Equivalent for `docker-compose up`.<br/>
    Usage: `pwsh start.ps1`.

-   `stop`

    Stops development environment.<br/>
    Equivalent for `docker-compose stop`.<br/>
    Usage: `pwsh stop.ps1`.

-   `prune`

    Stops all running containers of application, then:

    -   removes stopped containers
    -   removes networks
    -   removes volumens (if `-Full` flag is provided)

    Equivalent for `docker-compose down`.<br/>
    Usage: `pwsh prune.ps1`.<br/>
    You can use `-Full` flag if you want to remove application volumes but you don't have to.<br/>
    Example: `pwsh prune.ps1` or `pwsh prune.ps1 -Full`.

-   `cleanup`

    Removes restore, builds artifacts or nginx certificates.<br/>
    Usage: `pwsh cleanup.ps1 <PROJECTS>`.<br/>
    Where `<PROJECTS>` can be: `frontend`, `backend`, `nginx-certs`, `all`.<br/>
    First example: `pwsh cleanup.ps1 frontend`.<br/>
    Second example: `pwsh cleanup.ps1 frontend backend`.

## Proposed usage

-   Use `restore` command if you are starting you environment for the first time or after cleanup, it will speed the `build` command time up
-   Use `build` command on the first time and every time when docker files are changed
-   Use `start` command if you want to start development environment up
-   Use `stop` command if you want to stop development environment
-   Use `prune` command with `-Full` flag if you have problems with `start` command or want to remove every container, network and volume, if you want to keep your volumes do not add the `-Full` flag
-   Use `cleanup` command if you want to remove restore and build artifacts:
    -   `cleanup.ps1 frontend` for: `node_modules` and `dist` of npm project
    -   `cleanup.ps1 backend` for: `obj` and `bin` of dotnet core project
    -   `cleanup.ps1 nginx-certs` for: nginx certificates stored at `./src/nginx/certs` directory
    -   `cleanup.ps1 all` for all: `frontend`, `backend` and `nginx-certs`

Then your environment is up and running.

## Visual Studio Code tasks

To access available tasks type `Ctrl + Shift + P` on Windows or equivalent on other systems, select `Tasks: Run Task` and then select the task you want to run.

Available ones are:

-   `Restore: frontend` is `restore frontend` command: `pwsh ./src/scripts/restore.ps1 frontend`
-   `Restore: backend` is `restore backend` command: `pwsh ./src/scripts/restore.ps1 backend`
-   `Restore: all` is `restore all` command: `pwsh ./src/scripts/restore.ps1 all`
-   `Build: docker images` is `build` command: `pwsh ./src/scripts/build.ps1`
-   `Start: development environment` is `start` command: `pwsh ./src/scripts/start.ps1`
-   `Stop: development environment` is `stop` command: `pwsh ./src/scripts/stop.ps1`
-   `Prune: development environment` is `prune` command: `pwsh ./src/scripts/prune.ps1`
-   `Cleanup: frontend` is `cleanup frontend` command: `pwsh ./src/scripts/cleanup.ps1 frontend`
-   `Cleanup: backend` is `cleanup backend` command: `pwsh ./src/scripts/cleanup.ps1 backend`
-   `Cleanup: all` is `cleanup all` command: `pwsh ./src/scripts/cleanup.ps1 all`
