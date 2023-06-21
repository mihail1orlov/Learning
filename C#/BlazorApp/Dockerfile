# Start by using the base image from Microsoft with .NET 6.0 SDK installed
# We will need this for building our application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Set our work directory inside the container
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "BlazorApp.dll"]