using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.Mvc;
using MERSAP.Data;

namespace MERSAP.Controllers;

public class DataController : ODataController
{
    private readonly IDataRepository _repo;

    public DataController(IDataRepository repo)
    {
        _repo = repo;
    }

    [EnableQuery]
    public async Task<IActionResult> Get()
    {
        return Ok(await _repo.GetAllAsync());
    }
}


