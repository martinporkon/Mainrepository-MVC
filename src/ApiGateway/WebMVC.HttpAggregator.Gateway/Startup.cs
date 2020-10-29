using Catalog.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Order.Services;
using Sooduskorv_MVC.Middleware.SwaggerMiddleware;
using WebMVC.HttpAggregator.Gateway.Middleware;

namespace WebMVC.HttpAggregator.Gateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCustomGrpcClientFactoryMiddleware(Configuration);
            services.AddCustomSwagger(Configuration);
            services.AddHttpContextAccessor();
            services.AddResponseCaching();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseResponseCaching();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerAPI(Configuration);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<CatalogService.CatalogServiceClient>();
                endpoints.MapGrpcService<OrderService.OrderServiceClient>();
                endpoints.MapGrpcService<BasketService.BasketServiceClient>();
            });
        }
    }
}