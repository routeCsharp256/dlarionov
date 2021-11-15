using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OzonEdu.MerchandiseService.Api.GrpcServices;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptRequestAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Stubs;

namespace OzonEdu.MerchandiseService.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<MerchandiseGrpcService>();
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AddMediator(services);
            AddRepositories(services);
        }

        private static void AddMediator(IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IMerchReceiptApplicationRepository, MerchReceiptApplicationRepository>();
            services.AddScoped<IMerchReceiptRepository, MerchReceiptRepository>();
        }
    }
}
