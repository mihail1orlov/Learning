# MariaDBTest Project

## Description
The `MariaDBTest` project is designed to test the functionality of the Pomelo.EntityFrameworkCore.MySql provider.

## Project Setup
The following steps were taken for the initial setup of this project:

1. Creating a .NET console application:
   ```bash
   dotnet new console -n MariaDBTest
   ```

2. Adding the Pomelo.EntityFrameworkCore.MySql package:
   ```bash
   dotnet add package Pomelo.EntityFrameworkCore.MySql
   ```

3. Adding the Microsoft.EntityFrameworkCore.Design package:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0
   ```
   This package is needed for migration operations.

4. Creating an initial migration using Entity Framework Core:
   ```bash
   dotnet ef migrations add InitialCreate
   ```

After performing the migration, there is no need to update the database:

```bash
dotnet ef database update
```

The database is created, and its structure is updated.

## How to Use
- Ensure that you have the .NET SDK and EF Core CLI installed.
- Execute the above commands to set up your project.
- Configure the connection string to your MariaDB database and apply the migrations.

## Notes
- It's important to ensure the correctness of the database connection string.
- EF Core CLI is required for working with migrations.
