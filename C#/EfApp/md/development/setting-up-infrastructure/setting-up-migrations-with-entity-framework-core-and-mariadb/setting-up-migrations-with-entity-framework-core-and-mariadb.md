# Setting Up Migrations with Entity Framework Core and MariaDB

- [Setting Up Migrations with Entity Framework Core and MariaDB](#setting-up-migrations-with-entity-framework-core-and-mariadb)
  - [Required Packages](#required-packages)
  - [Creating Migrations](#creating-migrations)
  - [Applying Migrations to Database](#applying-migrations-to-database)


## Required Packages
Ensure you have installed the following packages:

1. **Pomelo.EntityFrameworkCore.MySql** for connecting to MariaDB.
   ```bash
   dotnet add package Pomelo.EntityFrameworkCore.MySql
   ```

2. **Microsoft.EntityFrameworkCore.Design** for migration functionality.
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0
   ```

## Creating Migrations
To create and apply migrations, follow these steps:

1. **Add EF Core Migration Tools**: Install EF Core command-line tools if not already installed.

2. **Create Initial Migration**:
   ```bash
   dotnet ef migrations add InitialCreate
   ```

   This will create the initial migration in your project.

## Applying Migrations to Database
After creating the migrations, apply them to your MariaDB database:

   ```bash
   dotnet ef database update
   ```

These steps will help set up your database and prepare it for integration with your application.

[Go back](../setting-up-infrastructure.md#setting-up-migrations-with-entity-framework-core-and-mariadb)