FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /source

COPY *.sln .
COPY TodoApp/*.csproj ./TodoApp/
RUN dotnet restore

COPY TodoApp/. ./TodoApp/
WORKDIR /source/TodoApp
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app
COPY --from=build /app/ ./
ENTRYPOINT [ "dotnet", "TodoApp.dll" ]