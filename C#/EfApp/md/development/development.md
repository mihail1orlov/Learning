# Development

- [Development](#development)
  - [Architecture and Project Design](#architecture-and-project-design)
  - [Step 0: Техническое описание функционирования системы](#step-0-техническое-описание-функционирования-системы)
  - [Step 1: Defining Domain Models](#step-1-defining-domain-models)
    - [In `TimeTracker.Domain`:](#in-timetrackerdomain)
  - [Step 2: Setting Up Infrastructure](#step-2-setting-up-infrastructure)
    - [In `TimeTracker.Infrastructure`:](#in-timetrackerinfrastructure)
  - [Step 3: Implementing Application Logic](#step-3-implementing-application-logic)
    - [In `TimeTracker.Application`:](#in-timetrackerapplication)
  - [Step 4: Setting Up API](#step-4-setting-up-api)
    - [In `TimeTracker.API`:](#in-timetrackerapi)
  - [Step 5:](#step-5)
    - [Integration Testing](#integration-testing)
    - [Docker and Deployment](#docker-and-deployment)
    - [Docker:](#docker)
    - [Deployment:](#deployment)
  - [Step 7: Documentation](#step-7-documentation)
  - [API versions](#api-versions)
  - [Update dependencies.](#update-dependencies)
  - [Code quality](#code-quality)
  - [Solution \& Project Setup Commands](#solution--project-setup-commands)

## Architecture and Project Design

```mermaid
graph TD;
    TimeTracker.API-->TimeTracker.Application;
    TimeTracker.Application-->TimeTracker.Domain;
    TimeTracker.Infrastructure-->TimeTracker.Domain;
```

- fix documentaion
  - implementation
    - steps for implementation
  - functioning of system (system operation)
    - launch the application (need to understand service or application)
      - subscribe on the events
        - chenge focus event
      - process event
      - 



## Step 0: Техническое описание функционирования системы

## Step 1: Defining Domain Models
### In `TimeTracker.Domain`:
- Define entities and aggregates (e.g., `TimeRecord`, `User`).
- Develop business rules and logic for these entities.

## Step 2: Setting Up Infrastructure
### In `TimeTracker.Infrastructure`:
- Migration
- Configure the Entity Framework context for database interaction.
- Implement the repository pattern for data access.
  
[Setting Up Infrastructure page](setting-up-infrastructure/setting-up-infrastructure.md)

## Step 3: Implementing Application Logic
### In `TimeTracker.Application`:
- Create services for performing business operations.
- Define DTOs (Data Transfer Objects).

## Step 4: Setting Up API
### In `TimeTracker.API`:
- Create controllers for handling HTTP requests.
- Configure routing, request validation, and response formatting.

## Step 5:  

### Integration Testing
- Write integration tests.
- Ensure the API's correct functioning and interaction with the database.

### Docker and Deployment
### Docker:
- Create a `Dockerfile` for the API.
- Use `docker-compose.yml` if necessary.

### Deployment:
- Deploy the application on the chosen platform.

## Step 7: Documentation
- Document your API (e.g., using Swagger).

## API versions

## Update dependencies.
Possibility to update the project to versions C# 8.0 and dotnet-ef to version 8.0.

## Code quality

## Solution & Project Setup Commands
These commands outline the steps to set up a .NET solution with a domain-driven design, including creating the necessary projects and adding dependencies among 
- Command to create a new solution
- Command to add existing projects to the solution
- Command to add references to other projects or packages

[Setup Commands page](solution--project-setup-commands/solution--project-setup-commands.md)


[Go back](../../README.md#development)