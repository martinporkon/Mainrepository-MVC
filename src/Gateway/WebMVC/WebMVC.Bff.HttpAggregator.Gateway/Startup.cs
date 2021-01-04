using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;
using Sooduskorv_MVC.Aids.Constants;
using Sooduskorv_MVC.Middleware.SecurityMiddleware;
using WebMVC.Bff.HttpAggregator.Gateway.Data;
using WebMVC.Bff.HttpAggregator.Gateway.Middleware;
using WebMVC.Bff.HttpAggregator.Gateway.Middleware.HealthChecks;

namespace WebMVC.Bff.HttpAggregator.Gateway
{
    public class Startup
    {
        public Startup(IConfiguration c) => Configuration = c;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMiddlewareAnalysis();
            services.AddCustomCors(Configuration);
            services.AddLogging();
            services.AddResponseCaching();
            /*services.AddSingleton(new LoggerFactory());*/
            services.AddHttpMiddleware(Configuration);
            services.AddHttpContextAccessor();
            /*services.AddCustomGrpcClientFactoryMiddleware(Configuration);*/
            services.AddCustomSwagger(Configuration);
            /*services.AddCustomIdentityMiddleware();#1#
            services.AddCustomAssemblies();*/
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString(DbConnection.Default));
            });
            /*Register.Services(services);*/
            /*services.AddHttpClient<IInterface, Service>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:44340/");
            });*/
            /*services.AddResponseCompression(options => { });
            /*var container = new ContainerBuilder();
            container.RegisterModule(new AssemblyModule());#1#
            services.AddCustomHealthChecks<ApplicationDbContext>();
            services.AddOcelot().AddDelegatingHandlers();*/
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, DiagnosticListener listener)
        {
            /*listener.SubscribeWithAdapter(new BasketSystemDiagnosticsListener(),
                new BasketListener());*/

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            /*app.UseSerilogRequestLogging();
            app.UseCors(Security.MyAllowSpecificOrigins);
            await app.UseOcelot();

            app.UseResponseCaching();*/
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            /*
            app.UseAuthentication();
            app.UseAuthorization();*/

            app.UseSwaggerAPI(Configuration);

            app.UseEndpoints(endpoints =>
            {
                /*endpoints.UseCustomHealthChecks(Configuration);*/
                endpoints.MapControllers();
                /*endpoints.MapServices(Configuration);*/
            });
        }
    }
}