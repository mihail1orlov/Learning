# TimescaleDB

Time-series storage on top of PostgreSQL. A handful of `.NET` samples that talk to it.

## Projects

- [`TimeScaleDb/`](TimeScaleDb) — direct ADO/Npgsql usage with a `TimescaleHelper`.
- [`Product/`](Product) — Web API + data layer, hand-rolled SQL.
- [`ProductApiEf/`](ProductApiEf) — same idea, but EF Core.
- [`MinimalApiDemoApp/`](MinimalApiDemoApp) — Minimal API on top of a TimescaleDB schema.

## Notes

- [`commands.txt`](commands.txt) — `docker run timescale/...` and migration commands.
