using System.Diagnostics;
using Basket.API.Data;
using Basket.API.Middleware.Authentication;
using Basket.API.Middleware.CustomHttpMiddleware;
using Basket.Core.Diagnostics;
using Basket.Domain.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sooduskorv_MVC.Aids.Constants;
using Sooduskorv_MVC.Middleware.Diagnostics;
using Sooduskorv_MVC.Middleware.SystemDiagnostics;
using WebMVC.Bff.HttpAggregator.Gateway.Middleware.HealthChecks;

namespace Basket.API
{
    public class Startup
    {
        public Startup(IConfiguration c) => Configuration = c;

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
            services.AddCustomHealthChecks<BasketApplicationDbContext>();
        }

        private static void registerRepositories(IServiceCollection s)
        {
            GetRepository.SetServiceProvider(s.BuildServiceProvider());
        }

        private void registerDbContexts(IServiceCollection s)
        {
            registerDbContext<BasketApplicationDbContext>(s);
        }

        protected virtual void registerDbContext<T>(IServiceCollection s) where T : DbContext
        {
            s.AddDbContext<T>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString(DbConnection.Default)));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DiagnosticListener listener)
        {
            listener.SubscribeWithAdapter(new BasketSystemDiagnosticsListener(),
                new BasketListener());

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
                // TODO for this service.
                endpoints.MapControllers();
                endpoints.MapServices(Configuration);
            });
        }
    }
}