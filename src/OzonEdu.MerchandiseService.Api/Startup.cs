using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using OzonEdu.MerchandiseService.Api.GrpcServices;

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
    }
}
