# Todo Application

This is a simple todo app written using **Angular** and **Dotnet Core**.
Server API is written using **GraphQL**.

Work in progress. See [roadmap](./ROADMAP.md) for more details.

# Development environment

The Client application supports auto-reload on change.
The server application restarts every backend code change. On server error, application waits for debugger attach and then restarts or for file change, then rebuilds backend and restarts it.

## Requirements:

-   Docker
-   Docker compose
-   Node.js v12.18.1
-   Dotnet Core Sdk 3.1
-   Visual Studio Code
-   Powershell Core 7

## Setup and startup:

Setup and startup of this project is super simple, just run these commands in your terminal:

-   `pwsh ./src/scripts/restore.ps1 all`
-   `pwsh ./src/scripts/build.ps1`
-   `pwsh ./src/scripts/start.ps1`

It will install all the necessary dependencies for every project, build docker images and start the whole environment up. Docker will ask you to share folders to docker containers, allow for it.

## Available services:

-   Client: [http://localhost/](http://localhost/)
-   Server: [http://localhost/info](http://localhost/info)
-   GraphQL endpoint: [http://localhost/graphql](http://localhost/graphql)
-   GraphQL Playground: [http://localhost/graphql/playground](http://localhost/graphql/playground)
-   GraphQL Voyager: [http://localhost/graphql/voyager](http://localhost/graphql/voyager)
-   PgAdmin 4: [http://localhost/pgadmin](http://localhost/pgadmin)
    -   Default login: `admin@backend.com`
    -   Default password: `SimplePassword1`

## Common scripts

There are some common scripts that help you efficiently manage your environment. Read more [here](./src/scripts/README.md).

## Code editor:

We are using **Visual Studio Core** as our main code editor.

Open [workspace file](./todo.code-workspace) using Visual Studio Code and install recommended extensions.

### VSCode tasks

You can access available tasks by pressing `Ctrl + Shift + P` on Windows or equivalent on other systems and typing `Tasks: Run Task`. You can find list of available tasks [here](src/scripts/README.md).

### VSCode debug configurations

-   `Attach to Dev.TodoApp.Server` - attaches the debugger to the server application. You can restart the application by pressing the restart button or by detaching and attaching debugger within 30 seconds. If the application crashes - it automatically waits for the debugger to attach and then restarts the server with debugger attached or waits for file change and restarts the app.
-   `Powershell: Launch Current File` - executes current powershell file and allows to debug it.
