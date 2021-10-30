using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OzonEdu.MerchandiseService.Api.Infrastructure.Filters;
using OzonEdu.MerchandiseService.Api.Infrastructure.Interceptors;
using OzonEdu.MerchandiseService.Api.Infrastructure.StartupFilters;

namespace OzonEdu.MerchandiseService.Api.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
                
                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();

                services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());

                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo {Title = "OzonEdu.MerchandiseService.Api", Version = "v1"});
                
                    options.CustomSchemaIds(x => x.FullName);
                });

                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
            });
            return builder;
        }
    }
}