# Todo Application

This is a simple todo app written using **Angular** and **Dotnet Core**.
Server API is written using **GraphQL**.

Work in progress. See [roadmap](./ROADMAP.md) for more details.

# Development environment

Client application supports auto reload on change.
Server application restarts every backend code change. On server error application waits for debugger attach and then restarts or for file change, then rebuilds backend and restarts it.

## Requirements:

-   Docker
-   Docker compose
-   Node.js v12.18.1
-   Dotnet Core Sdk 3.1
-   Visual Studio Code

## Performance note:

-   Visual Studio Code terminal may be slow on some older computers. If you want to make build and startup times faster - use your system terminal instead of VSCode integrated terminal.
-   Sometimes docker does not want to download and extract all images (gets frozen) when using VSCode integrated terminal. If this happens, use your system terminal, it will install all the necessary dependencies without any problem.

## Setup and startup:

Setup and startup of this project is super simple, just paste this two commands below into your terminal:

-   `docker-compose -f src/docker-compose.yml -f src/docker-compose.dev.yml build`
-   `docker-compose -f src/docker-compose.yml -f src/docker-compose.dev.yml up`

It will install all the necessary dependencies for every project automatically and start the whole environment up. Docker will ask you to share folders to docker containers, allow for it.

## Available services:

-   Client: [http://localhost:4000](http://localhost:4000)
-   Server: [http://localhost:5000](http://localhost:5000)
-   GraphQL endpoint: [http://localhost:5000/graphql](http://localhost:5000/graphql)
-   GraphQL Playground: [http://localhost:5000/graphql/playground](http://localhost:5000/graphql/playground)
-   GraphQL Voyager: [http://localhost:5000/graphql/voyager](http://localhost:5000/graphql/voyager)
-   PgAdmin 4: [http://localhost:5050](http://localhost:5050)
    -   Default login: `admin@backend.com`
    -   Default password: `SimplePassword1`

## Code editor:

We are using **Visual Studio Core** as our main code editor.

Open [workspace](./todo.code-workspace) file using Visual Studio Code and install recommended extensions.

### VSCode tasks

You can access available tasks by pressing `Ctrl + Shift + P` on Windows or equivalent on other systems and typing `Tasks: Run Task`. Available tasks are:

-   Build TodoApp in debug configuration
    Builds TodoApp images by running `docker-compose -f src/docker-compose.yml -f src/docker-compose.dev.yml build` command
-   Run TodoApp in debug configuration
    Builds TodoApp using previous task and starts application environment by running `docker-compose -f src/docker-compose.yml -f src/docker-compose.dev.yml up` command

Note that `Run TodoApp in debug configuration` will run automatically on every workspace open. Just wait a while for environment startup.

### VSCode debug configurations

There is only one debug configuration for TodoApp.Server backend project. You can select it form the debug side panel of VSCode.

-   `Attach to TodoApp.Server` - attaches debugger to server application. You can restart application by pressing restart button or by detaching and attaching debugger within 30 seconds. If application crashes - it automatically waits for debugger to attach and then restarts the server with debugger attached or waits for file change and restarts app.
