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
        string dbName = "postgres",
        string password = "postgres",
        string port = "5432")
    {
        Host = host;
        User = user;
        DBname = dbName;
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

    //
    // Procedure - Creating a relational table:
    // Create a table for basic relational data and
    // populate it with a few fake sensors
    //
    public void CreateRelationalData()
    {
        //use one connection to use for all three commands below.
        using (var conn = getConnection())
        {
            using (var command = new NpgsqlCommand("DROP TABLE IF EXISTS sensors cascade", conn))
            {
                command.ExecuteNonQuery();
                Console.Out.WriteLine("Finished dropping table (if existed)");
            }

            using (var command = new NpgsqlCommand("CREATE TABLE sensors (id SERIAL PRIMARY KEY, type TEXT, location TEXT);", conn))
            {
                command.ExecuteNonQuery();
                Console.Out.WriteLine("Finished creating the sensors table");
            }

            // Create the list of sensors as key/value pairs to insert next
            var sensors = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("a","floor"),
                    new KeyValuePair<string, string>("a","ceiling"),
                    new KeyValuePair<string, string>("b","floor"),
                    new KeyValuePair<string, string>("b","ceiling")
                };

            // Iterate over the list to insert it into the newly
            // created relational table using parameter substitution
            foreach (KeyValuePair<string, string> kvp in sensors)
            {
                using (var command = new NpgsqlCommand("INSERT INTO sensors (type, location) VALUES (@type, @location)", conn))
                {
                    command.Parameters.AddWithValue("type", kvp.Key);
                    command.Parameters.AddWithValue("location", kvp.Value);

                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
            }
        }
    }

    //
    // Procedure - Creating a hypertable:
    // Create a new table to store time-series data and create
    // a new TimescaleDB hypertable using the new table. It is
    // partitioned on the 'time' column
    public void CreateHypertable()
    {
        //use one connection to use for all three commands below.
        using (var conn = getConnection())
        {
            using (var command = new NpgsqlCommand("DROP TABLE IF EXISTS sensor_data CASCADE;", conn))
            {
                command.ExecuteNonQuery();
                Console.Out.WriteLine("Dropped sensor_data table if it existed");
            }

            using (var command = new NpgsqlCommand(@"CREATE TABLE sensor_data (
                                           time TIMESTAMPTZ NOT NULL,
                                           sensor_id INTEGER,
                                           temperature DOUBLE PRECISION,
                                           cpu DOUBLE PRECISION,
                                           FOREIGN KEY (sensor_id) REFERENCES sensors (id)
                                           );", conn))
            {
                command.ExecuteNonQuery();
                Console.Out.WriteLine("Created sensor_data table to store time-series data");
            }

            using (var command = new NpgsqlCommand("SELECT create_hypertable('sensor_data', 'time');", conn))
            {
                command.ExecuteNonQuery();
                Console.Out.WriteLine("Converted the sensor_data table into a TimescaleDB hypertable!");
            }
        }
    }

    //
    // Procedure - Insert time-series data:
    // With the hypertable in place, insert data using the PostgreSQL
    // supplied 'generate_series()' function, iterating over our small list
    // of sensors from Step 2.
    public void InsertData()
    {
        using (var conn = getConnection())
        {
            // This query creates one row of data every minute for each
            // sensor_id, for the last 24 hours ~= 1440 readings per sensor
            var sql = @"INSERT INTO sensor_data
                            SELECT generate_series(now() - interval '24 hour',
                                                    now(),
                                                    interval '1 minute') AS time,
                            @sid as sensor_id,
                            random()*100 AS temperature,
                            random() AS cpu";

            // We created four sensors in Step 2 and so we iterate over their
            // auto generated IDs to insert data. This could be modified
            // using a larger list or updating the SQL to JOIN on the 'sensors'
            // table to get the IDs for data creation.
            for (int i = 1; i <= 4; i++)
            {
                using (var command = new NpgsqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("sid", i);

                    int nRows = command.ExecuteNonQuery();
                    Console.Out.WriteLine(String.Format("Number of rows inserted={0}", nRows));
                }
            }
        }
    }

    //
    // Procedure - Query TimescaleDB
    // With time-series data inserted, run a 'time_bucket()' query
    // on the data in order to aggregate our 1-minute cpu data into buckets
    // of 5-minute averages.
    public void RunQueryExample()
    {
        string sql = @"
                SELECT sensor_id, time_bucket('5 minutes', time) AS five_min, avg(cpu)
                FROM sensor_data
                    INNER JOIN sensors ON sensors.id = sensor_data.sensor_id
                GROUP BY sensor_id, five_min
                ORDER BY sensor_id, five_min DESC;";

        var conn = getConnection();
        using (var cmd = new NpgsqlCommand(sql, conn))
        {
            using (NpgsqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read()) Console.WriteLine($"{rdr.GetDouble(0)} - {rdr.GetTimeStamp(1)} - {rdr.GetDouble(2)}");
            }
        }

        conn.Close();
    }

    // Helper method to get a connection for the execute function
    private NpgsqlConnection getConnection()
    {
        var connection = new NpgsqlConnection(conn_str);
        connection.Open();
        return connection;
    }
}