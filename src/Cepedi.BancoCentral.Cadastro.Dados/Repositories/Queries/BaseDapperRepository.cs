using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cepedi.BancoCentral.Cadastro.Data.Repositories.Queries;

public abstract class BaseDapperRepository{
    private readonly string _connectionString = default!;

    public BaseDapperRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public virtual async Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, DynamicParameters parametros)
    {
        using var conn = GetConnection();
        conn.Open();

        var result = await conn.QueryAsync<T>(query,parametros);
        conn.Close();

        return result.ToList();
    }

    private IDbConnection GetConnection()
    {
        var sqlConnection = new SqlConnection(_connectionString);
        return sqlConnection;
    }
}

