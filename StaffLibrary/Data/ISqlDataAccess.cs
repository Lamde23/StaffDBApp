using Dapper;

namespace StaffLibrary.Data
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadDataAsync<T, U>(string sql, U parameters, string connectionStringName = "Default");
        Task InsertStaffAsync(string storedProcedure, DynamicParameters data, string connnectionStringName = "Default");
        Task SaveDataAsync(string storedProcedure,
                           DynamicParameters data,
                           string connnectionStringName = "Default");
    }
}