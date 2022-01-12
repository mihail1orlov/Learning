using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;

namespace DataAccess.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _configuration;

    public SqlDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<T>> LoadData<T, TP>(string storedProcedure, TP parameters, string connectionId = "Default")
    {
        await using NpgsqlConnection connection = new(_configuration.GetConnectionString(connectionId));
        await using (var command = new NpgsqlCommand("call sp_user_insert(:p_id, :p_fn, :p_ln, :p_age)", connection))
        {
            command.Parameters.AddWithValue("p_id", NpgsqlDbType.Integer).Value = 9;
            command.Parameters.AddWithValue("p_fn", NpgsqlDbType.Varchar).Value = Guid.NewGuid().ToString("N").ToUpper();
            command.Parameters.AddWithValue("p_ln", NpgsqlDbType.Varchar).Value = Guid.NewGuid().ToString("N").ToUpper();
            command.Parameters.AddWithValue("p_age", NpgsqlDbType.Double).Value = new Random().Next(0, 99);
            command.CommandType = CommandType.Text;
            connection.Open();
            int affectedCount = command.ExecuteNonQuery();
        }

        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.Text);
    }

    public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default")
    {
        await using NpgsqlConnection connection = new (_configuration.GetConnectionString(connectionId));
        await connection.QueryAsync(storedProcedure, parameters, commandType: CommandType.Text);
    }
}
