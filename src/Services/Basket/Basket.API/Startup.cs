using Basket.API.Data;
using Basket.API.Middleware;
using Basket.Infra;
using Basket.Infra.Basket;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sooduskorv_MVC.Middleware.SwaggerMiddleware;

namespace Basket.API
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
            services.AddControllers()
                .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddGrpc();
            services.AddCustomSwagger(Configuration);
            services.AddCustomAuthentication(Configuration);
            services.AddDbContext<BasketApplicationDbContext>(options => // TODO !!
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocaldb;Database=BasketDB;Trusted_Connection=True;");
            });
            /*services.AddDbContext<BasketDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocaldb;Database=BasketDB;Trusted_Connection=True;");
            });*/
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerAPI(Configuration);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<BasketRepository>();
            });
        }
    }
}