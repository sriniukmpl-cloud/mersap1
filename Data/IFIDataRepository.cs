using MERSAP.Models;

namespace MERSAP.Data;

public interface IFIDataRepository
{
    Task<IEnumerable<FIDataDto>> GetAllAsync();
}
