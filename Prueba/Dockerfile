FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /app
COPY . ./
RUN dotnet restore DockerNetExample/DockerNetExample.csproj
RUN dotnet publish DockerNetExample/DockerNetExample.csproj -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /app
COPY --from=build /app/published-app .
ENTRYPOINT [ "dotnet", "DockerNetExample.dll" ]