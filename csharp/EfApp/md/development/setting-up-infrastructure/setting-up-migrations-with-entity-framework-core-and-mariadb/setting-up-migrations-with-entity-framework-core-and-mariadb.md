# EF Core migrations with MariaDB

How to wire up Entity Framework Core to a MariaDB instance and create the first migration.

## Required packages

EF Core doesn't ship a MariaDB/MySQL provider in-box — use [Pomelo](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql):

```bash
dotnet add package Pomelo.EntityFrameworkCore.MySql
```

You also need the design-time package to use `dotnet ef`:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.0
```

(Pin the version to whatever matches your `.NET` runtime.)

## Create the initial migration

Once `DbContext`, entities, and the connection string are in place:

```bash
dotnet ef migrations add InitialCreate
```

This generates a `Migrations/` folder containing the C# code that builds the schema.

## Apply migrations to the database

```bash
dotnet ef database update
```

EF Core connects, creates `__EFMigrationsHistory` if needed, and runs every pending migration in order.

## Further reading

- [Understanding `__EFMigrationsHistory`](__efmigrationshistory-table/__efmigrationshistory-table.md) — what the table is, what its columns mean, and how not to break it.
