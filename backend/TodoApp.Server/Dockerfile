FROM mcr.microsoft.com/dotnet/core/aspnet AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk AS build
WORKDIR /src
COPY . .
WORKDIR "/src/TodoApp.Server"
RUN dotnet build "TodoApp.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoApp.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoApp.Server.dll"]
