
# Understanding the __EFMigrationsHistory Table

## Overview
The `__EFMigrationsHistory` table is an integral part of the Entity Framework (EF) Core's migrations feature. It is automatically created in your database when you apply the first migration using EF Core. This table plays a crucial role in managing database schema changes over time.

## Purpose of the __EFMigrationsHistory Table
- **Tracking Migrations**: This table keeps a record of all the migrations that have been applied to the database. Each row represents a single migration.
- **Schema Synchronization**: It helps in synchronizing the database schema with the model's state in your application, ensuring consistency.
- **Migration Management**: EF Core uses this table to determine which migrations have been applied and which are pending, enabling smooth schema evolution.

## Structure of the Table
- **MigrationId**: A unique identifier for each migration, typically the name of the migration class.
- **ProductVersion**: The version of EF Core that was used to generate the migration.

## Best Practices
- **Do Not Modify Manually**: It's crucial not to alter this table manually. Changes should be made only through EF Core migration commands.
- **Regular Backups**: Consider regular backups of this table, especially before applying new migrations in a production environment.

## Common Scenarios
- **Rolling Back Migrations**: When rolling back migrations, EF Core updates this table to reflect the changes.
- **Database Update**: During the `database update` operation, EF Core checks this table to apply only the necessary migrations.

Understanding the `__EFMigrationsHistory` table is key to effectively managing and troubleshooting EF Core migrations.

[Official site](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/history-table)

[Go back](../setting-up-migrations-with-entity-framework-core-and-mariadb.md#understanding-the-__efmigrationshistory-table-page)