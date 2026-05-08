# The `__EFMigrationsHistory` table

When you apply your first EF Core migration, EF Core creates a tracking table called `__EFMigrationsHistory` in your database. This is how it knows which migrations have already run.

## What it does

- **Tracks migrations.** One row per migration that has been applied.
- **Synchronises schema with code.** EF Core reads this table to decide which migrations are missing and need to run.
- **Enables rollback.** When you `dotnet ef migrations remove` or run a `Down` step, this table is updated to match.

## Columns

| Column           | Meaning                                                              |
| ---------------- | -------------------------------------------------------------------- |
| `MigrationId`    | The unique migration name (timestamp + class name from `Migrations/`) |
| `ProductVersion` | The EF Core version that generated the migration                     |

## Best practices

- **Don't edit it by hand.** The only sanctioned way to modify it is through `dotnet ef` commands. Manual edits will eventually cause migrations to fail in confusing ways.
- **Back it up before risky migrations.** If you're running a destructive migration in production, snapshot the table (and ideally the whole DB) first.
- **Same DB, same code.** If two services share a database, only one of them should run migrations.

## Common scenarios

- **Rolling back** — `dotnet ef database update <PreviousMigration>` runs the `Down` methods and removes rows from `__EFMigrationsHistory`.
- **Database update** — `dotnet ef database update` applies every migration whose ID is not yet in the table.

## Reference

- [Microsoft Docs: history table](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/history-table)
