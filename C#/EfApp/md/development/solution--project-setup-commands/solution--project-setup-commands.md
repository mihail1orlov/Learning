# Solution & Project Setup Commands

These commands outline the steps to set up a .NET solution with a domain-driven design, including creating the necessary projects and adding dependencies among 

- [Solution \& Project Setup Commands](#solution--project-setup-commands)
  - [Creating Projects](#creating-projects)
    - [Solution Creation](#solution-creation)
    - [Domain Project](#domain-project)
    - [Infrastructure Project](#infrastructure-project)
    - [Application Project](#application-project)
    - [API Project](#api-project)
  - [Adding Dependencies](#adding-dependencies)
    - [Add Domain Dependencies to Application and Infrastructure](#add-domain-dependencies-to-application-and-infrastructure)
    - [Add Application Dependency to API](#add-application-dependency-to-api)


## Creating Projects
### Solution Creation
```bash
dotnet new sln -n TimeTracker
```
### Domain Project
```bash
dotnet new classlib -n TimeTracker.Domain
dotnet sln add TimeTracker.Domain/TimeTracker.Domain.csproj
```
### Infrastructure Project
```bash
dotnet new classlib -n TimeTracker.Infrastructure
dotnet sln add TimeTracker.Infrastructure/TimeTracker.Infrastructure.csproj
```
### Application Project
```bash
dotnet new classlib -n TimeTracker.Application
dotnet sln add TimeTracker.Application/TimeTracker.Application.csproj
```
### API Project
```bash
dotnet new webapi -n TimeTracker.API
dotnet sln add TimeTracker.API/TimeTracker.API.csproj
```
## Adding Dependencies
### Add Domain Dependencies to Application and Infrastructure
```bash
dotnet add TimeTracker.Application/TimeTracker.Application.csproj reference TimeTracker.Domain/TimeTracker.Domain.csproj
dotnet add TimeTracker.Infrastructure/TimeTracker.Infrastructure.csproj reference TimeTracker.Domain/TimeTracker.Domain.csproj
```
### Add Application Dependency to API
```bash
dotnet add TimeTracker.API/TimeTracker.API.csproj reference TimeTracker.Application/TimeTracker.Application.csproj
```

[Go back](../development.md#timetracker-project-setup-commands)