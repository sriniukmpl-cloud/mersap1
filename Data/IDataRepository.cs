using MERSAP.Models;

namespace MERSAP.Data;

public interface IDataRepository
{
    Task<IEnumerable<DataDto>> GetAllAsync();
}
