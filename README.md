# Todo Application

This is simple todo app written using **Angular** and **Dotnet Core**.
Server API is written using **GraphQL**.

Work in progress. See [roadmap](./ROADMAP.md) for more details.

# How to setup development environment

## Requirements:

-   Docker
-   Docker compose
-   Node.js v12.18.1
-   Dotnet Core Sdk 3.1
-   Visual Studio Code

## Performance note:

-   Visual Studio Code terminal may be slow on some older computers. If you want to make build and startup times faster - use your system terminal instead of VSCode integrated terminal.
-   Sometimes docker does not want to download and extract all images (gets frozen) when using VSCode integrated terminal. If this happens, use your system terminal, it will install all necessary dependencies without any problem.

## Setup and startup:

Setup and startup of this project is super simple, just paste this two commands below into your terminal:

-   `docker-compose -f src/docker-compose.yml -f src/docker-compose.dev.yml build`
-   `docker-compose -f src/docker-compose.yml -f src/docker-compose.dev.yml up`

It will install all necessary dependencies for every project automatically and start the whole environment up. Docker will ask you for share folders to docker containers, allow for it.

## Available services:

-   Client: [http://localhost:4000](http://localhost:4000)
-   Server: [http://localhost:5000](http://localhost:5000)
-   GraphQL endpoint: [http://localhost:5000/graphql](http://localhost:5000/graphql)
-   GraphQL Playground: [http://localhost:5000/graphql/playground](http://localhost:5000/graphql/playground)
-   GraphQL Voyager: [http://localhost:5000/graphql/voyager](http://localhost:5000/graphql/voyager)
-   PgAdmin 4: [http://localhost:5050](http://localhost:5050)
    -   Default login: `admin@backend.com`
    -   Default password: `SimplePassword1`
