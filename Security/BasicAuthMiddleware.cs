using System.Net;
using System.Text;

namespace MERSAP.Security;

public class BasicAuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _config;

    public BasicAuthMiddleware(RequestDelegate next, IConfiguration config)
    {
        _next = next;
        _config = config;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments("/odata"))
        {
            if (!context.Request.Headers.TryGetValue("Authorization", out var auth))
            {
                await Reject(context);
                return;
            }

            var encoded = auth.ToString().Replace("Basic ", "");
            var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
            var parts = decoded.Split(':');

            if (parts.Length != 2 ||
                parts[0] != _config["Security:BasicAuth:Username"] ||
                parts[1] != _config["Security:BasicAuth:Password"])
            {
                await Reject(context);
                return;
            }
        }

        await _next(context);
    }

    private static async Task Reject(HttpContext ctx)
    {
        ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        ctx.Response.Headers["WWW-Authenticate"] = "Basic";
        await ctx.Response.WriteAsync("Unauthorized");
    }
}


