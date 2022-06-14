FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /app
COPY . .
RUN dotnet restore TodoApp.csproj
RUN dotnet publish TodoApp.csproj -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR  /app
COPY --from=build /app/published-app /app
ENTRYPOINT [ "dotnet", "TodoApp.dll" ]