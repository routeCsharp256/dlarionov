using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OzonEdu.MerchandiseService.Api.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var versionObject = new
            {
                version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version",
                serviceName = Assembly.GetExecutingAssembly().GetName().Name ?? "no name"
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(versionObject));
        }
    }
}