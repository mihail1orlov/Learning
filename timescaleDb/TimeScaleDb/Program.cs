// Create a new instance of our helper class. This class
// contains all of the methods for interacting with
// TimescaleDB for this tutorial
TimescaleHelper ts = new(host: "192.168.1.202", password: "12344321");

// Procedure - Connecting .NET to TimescaleDB:
// Verify that the program can connect
// to the database and that TimescaleDB is installed!
ts.CheckDatabaseConnection();

Console.ReadKey();