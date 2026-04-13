using Dapper;
using Microsoft.Data.SqlClient;
using MERSAP.Models;

namespace MERSAP.Data;

public class DataRepository : IDataRepository
{
    private readonly IConfiguration _config;

    public DataRepository(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<DataDto>> GetAllAsync()
    {
        var sql = """
            select * from VW_Merch where billdate >='2026-03-25'  and TotalSales>0;
        """;

        using var conn = new SqlConnection(
            _config.GetConnectionString("SqlServerDb"));

        return await conn.QueryAsync<DataDto>(sql,commandTimeout: 900);
        
    }
}
