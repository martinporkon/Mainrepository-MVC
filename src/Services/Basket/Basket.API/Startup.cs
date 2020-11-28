using Basket.API.Data;
using Basket.API.Middleware;
using Basket.API.Middleware.Authentication;
using Basket.API.Middleware.CustomHttpMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            /*services.AddControllers()
                .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);*/
            services.AddGrpc();
            services.AddHttpContextAccessor();
            services.AddOptions();
            services.AddCustomSwagger(Configuration);
            services.AddCustomAuthentication(Configuration);
            services.AddDbContext<BasketApplicationDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });
            /*services.AddDbContext<BasketDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocaldb;Database=BasketDB;Trusted_Connection=True;");
            });*/

            /*services.AddHealthChecks()
                    .AddDbContextCheck<IdentityDbContext>();*/
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerAPI(Configuration);

            app.UseEndpoints(endpoints =>
            {
                /*endpoints.MapDefaultHealthChecks();*/
                endpoints.MapControllers();
                endpoints.MapDistributedServices(Configuration);
            });
        }
    }
}