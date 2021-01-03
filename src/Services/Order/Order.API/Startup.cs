using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Order.API.Data;
using Order.API.Middleware;
using Order.Infra;

namespace Order.API
{
    public class Startup
    {
        public Startup(IConfiguration c) => Configuration = c;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddGrpc();
            services.AddHttpContextAccessor();
            services.AddOptions();
            services.AddCustomSwagger(Configuration);
            services.AddCustomAuthentication(Configuration);
            services.AddDbContext<OrderApplicationDbContext>(options =>  // TODO ???
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
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
            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            /*app.Use(async (context, next) =>
            {
                context.Response.OnStarting(() =>
                {
                    // do something
                    /*return Task.CompletedTask;
                });

                await next.Invoke();
            });*/


            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerAPI(Configuration);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health/live");
                endpoints.MapControllers();
            });
        }
    }
}