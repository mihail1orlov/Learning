// Create a new instance of our helper class. This class
// contains all of the methods for interacting with
// TimescaleDB for this tutorial
TimescaleHelper ts = new(host: "192.168.1.202", password: "12344321", dbName: "MinimalApiUserDb");

// Procedure - Connecting .NET to TimescaleDB:
// Verify that the program can connect
// to the database and that TimescaleDB is installed!
ts.CheckDatabaseConnection();

// Procedure - Creating a relational table:
// Create a table for basic relational data and
// populate it with a few fake sensors
ts.CreateRelationalData();

// Procedure - Creating a hypertable
// Create a new table and make it a hypertable to store
// the generated time-series data
ts.CreateHypertable();

// Procedure - Insert time-series data
// Insert time-series data using the built-in
// PostgreSQL function generate_series()
ts.InsertData();

// Procedure - Query TimescaleDB
// Query the data using the Timescale time_bucket() function
ts.RunQueryExample();

Console.ReadKey();