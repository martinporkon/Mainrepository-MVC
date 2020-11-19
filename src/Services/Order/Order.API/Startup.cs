using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Order.API.Data;
using Order.API.Middleware;
using Order.Infra;
using Order.Infra.Order;
using Sooduskorv_MVC.Middleware.SwaggerMiddleware;

namespace Order.API
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
            services.AddDbContext<OrderApplicationDbContext>(options =>  // TODO ???
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocaldb;Database=OrderDB;Trusted_Connection=True;");
            });
            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocaldb;Database=OrderDB;Trusted_Connection=True;");
            });
            services.AddDbContext<AddressDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocaldb;Database=OrderDB;Trusted_Connection=True;");
            });
            services.AddDbContext<ShippingDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocaldb;Database=OrderDB;Trusted_Connection=True;");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSwaggerAPI(Configuration);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<OrderRepository>();
            });
        }
    }
}