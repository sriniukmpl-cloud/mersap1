using Dapper;
using Microsoft.Data.SqlClient;
using MERSAP.Models;

namespace MERSAP.Data;

public class FIDataRepository : IFIDataRepository
{
    private readonly IConfiguration _config;

    public FIDataRepository(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<FIDataDto>> GetAllAsync()
    {
        var sql = """
            select * from TaxSumm;
        """;

        using var conn = new SqlConnection(
            _config.GetConnectionString("SqlServerDb"));

        return await conn.QueryAsync<FIDataDto>(sql,commandTimeout: 900);
        
    }
}
