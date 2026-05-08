# MariaDBTest

A bare-bones .NET console app that exercises [`Pomelo.EntityFrameworkCore.MySql`](https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql) against a MariaDB database — basically a smoke test for the EF Core ↔ MariaDB pipeline.

## How it was set up

```bash
# 1. New console app
dotnet new console -n MariaDBTest

# 2. EF Core + Pomelo provider
dotnet add package Pomelo.EntityFrameworkCore.MySql

# 3. Design-time package (needed for `dotnet ef`)
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0

# 4. Initial migration
dotnet ef migrations add InitialCreate

# 5. Apply to the database
dotnet ef database update
```

## To run

1. Spin up a MariaDB instance (Docker is easiest — see [`../EfApp/md/environment/environment.md`](../EfApp/md/environment/environment.md)).
2. Set the connection string to point at it.
3. `dotnet ef database update` to create the schema.
4. `dotnet run`.

## Notes

- The connection string is the only thing that ever needs to change between machines.
- The `dotnet-ef` global tool must be installed (`dotnet tool install --global dotnet-ef`) before you can run any `dotnet ef` commands.
