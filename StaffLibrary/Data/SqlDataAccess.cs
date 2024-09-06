using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StaffLibrary.Data;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    //Giving connection to sql server, Dapper queries SQL and returns as value
    public async Task<List<T>> LoadDataAsync<T,U>(string sql, U parameters, string connectionStringName = "Default"){
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionStringName));
        var rows = await connection.QueryAsync<T>(sql, parameters, commandType: CommandType.StoredProcedure);

        return rows.ToList();
    }

    public async Task InsertStaffAsync(string storedProcedure, DynamicParameters data, string connectionStringName = "Default")
    {
        using var connection = new SqlConnection(_config.GetConnectionString(connectionStringName));
        await connection.ExecuteAsync(storedProcedure, data, commandType: CommandType.StoredProcedure);

    }

    //Generic save data and payment
    public async Task SaveDataAsync(string storedProcedure,
                            DynamicParameters data, //From Dapper, allows output of data
                            string connnectionStringName = "Default")
    {
        using var connection = new SqlConnection(_config.GetConnectionString(connnectionStringName));

        await connection.ExecuteAsync(storedProcedure,
                                       data,
                                       commandType: System.Data.CommandType.StoredProcedure);
        //Using ExecuteAsync, convert void to Task return and we return the connection
    }
}
