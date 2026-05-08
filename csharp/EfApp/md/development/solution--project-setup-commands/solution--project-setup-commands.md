# Solution & project setup commands

The exact `dotnet` CLI commands used to scaffold the four-project DDD layout.

## Create the solution and projects

```bash
# Solution
dotnet new sln -n TimeTracker

# Domain layer (class library)
dotnet new classlib -n TimeTracker.Domain
dotnet sln add TimeTracker.Domain/TimeTracker.Domain.csproj

# Infrastructure layer (class library)
dotnet new classlib -n TimeTracker.Infrastructure
dotnet sln add TimeTracker.Infrastructure/TimeTracker.Infrastructure.csproj

# Application layer (class library)
dotnet new classlib -n TimeTracker.Application
dotnet sln add TimeTracker.Application/TimeTracker.Application.csproj

# API layer (ASP.NET Core Web API)
dotnet new webapi -n TimeTracker.API
dotnet sln add TimeTracker.API/TimeTracker.API.csproj
```

## Wire up project references

```bash
# Application and Infrastructure both depend on Domain
dotnet add TimeTracker.Application/TimeTracker.Application.csproj \
    reference TimeTracker.Domain/TimeTracker.Domain.csproj

dotnet add TimeTracker.Infrastructure/TimeTracker.Infrastructure.csproj \
    reference TimeTracker.Domain/TimeTracker.Domain.csproj

# API depends on Application
dotnet add TimeTracker.API/TimeTracker.API.csproj \
    reference TimeTracker.Application/TimeTracker.Application.csproj
```

## Sanity-check the result

```bash
dotnet sln list
dotnet build
```

`build` will fail loudly if a reference is missing or a dependency is the wrong way around.
