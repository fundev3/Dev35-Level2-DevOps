FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /TodoApp
EXPOSE 80

# Build image which builds the project and prepares the assets for publishing
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TodoApp.csproj", ""]
RUN dotnet restore "./TodoApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./TodoApp.csproj" -c Release -o /TodoApp/build

# Publish image which sets up the optimized version of the app into a folder
FROM build AS publish
RUN dotnet publish "./TodoApp.csproj" -c Release -o /app/publish

# Final image which only contains the published content of the project
# This is where the resulting files of the published app are moved to
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", TodoApp.dll"]
