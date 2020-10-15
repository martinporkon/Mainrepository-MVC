using Basket.API.Data;
using Basket.API.Middleware;
using Basket.Infra;
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
            services.AddControllers()
                .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddSwagger(Configuration);
            services.AddCustomAuthentication(Configuration);
            services.AddDbContext<BasketApplicationDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocaldb;Database=BasketDB;Trusted_Connection=True;");
            });
            services.AddDbContext<BasketDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocaldb;Database=BasketDB;Trusted_Connection=True;");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "Catalog V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}