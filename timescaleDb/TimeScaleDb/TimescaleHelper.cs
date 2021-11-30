using Npgsql;
// This class contains all of the methods needed to complete the
// quick-start, providing a sample of each database operation in total
// to refer to later.
public class TimescaleHelper
{
    private static string Host = "";
    private static string User = "";
    private static string DBname = "";
    private static string Password = "";
    private static string Port = "";
    private static string conn_str = "";

    //
    // This is the constructor for our TimescaleHelper class
    //
    public TimescaleHelper(string host = "localhost",
        string user = "postgres",
        string dbname = "postgres",
        string password = "postgres",
        string port = "5432")
    {
        Host = host;
        User = user;
        DBname = dbname;
        Password = password;
        Port = port;
        // Build connection string using the parameters above
        conn_str = $"Server={Host};Username={User};Database={DBname};Port={Port};Password={Password};SSLMode=Prefer";
    }

    //
    // Procedure - Connecting .NET to TimescaleDB:
    // Check the connection TimescaleDB and verify that the extension
    // is installed in this database
    //
    public void CheckDatabaseConnection()
    {
        // get one connection for all SQL commands below
        using (var conn = getConnection())
        {

            var sql = "SELECT default_version, comment FROM pg_available_extensions WHERE name = 'timescaledb';";

            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();

                if (!rdr.HasRows)
                {
                    Console.WriteLine("Missing TimescaleDB extension!");
                    conn.Close();
                    return;
                }

                while (rdr.Read())
                {
                    Console.WriteLine("TimescaleDB Default Version: {0}\n{1}", rdr.GetString(0), rdr.GetString(1));
                }
                conn.Close();
            }
        }

    }

    // Helper method to get a connection for the execute function
    private NpgsqlConnection getConnection()
    {
        var connection = new NpgsqlConnection(conn_str);
        connection.Open();
        return connection;
    }
}