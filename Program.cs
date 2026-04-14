using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using MERSAP.Models;
using MERSAP.Data;
using MERSAP.Security;
var builder = WebApplication.CreateBuilder(args);
 
// ?? Controllers + OData
builder.Services
    .AddControllers()
    .AddOData(opt =>
        opt.AddRouteComponents("odata", GetEdmModel())
           .Select()
           .Filter()
           .OrderBy()
           .Count()
           .SetMaxTop(800000));
 
// ?? Repositories
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddScoped<IFIDataRepository, FIDataRepository>();
 
// ?? OpenAPI (Swagger JSON)
builder.Services.AddOpenApi();
 
var app = builder.Build();
 
// ?? Development OpenAPI endpoint
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
 
app.UseHttpsRedirection();
 
// ?? Basic Auth must be BEFORE MapControllers
app.UseMiddleware<BasicAuthMiddleware>();
 
// ?? THIS IS CRITICAL
app.MapControllers();
 
app.Run();
 
// ================= EDM MODEL =================

static Microsoft.OData.Edm.IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
 
    builder.EntitySet<DataDto>("Data")
        .EntityType.HasKey(x => x.SNo);

    builder.EntitySet<FIDataDto>("FIData")
        .EntityType.HasKey(x => x.PosCode);
 
    return builder.GetEdmModel();
}
