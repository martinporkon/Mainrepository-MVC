using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebMVC.Bff.HttpAggregator.Gateway.Data;
using WebMVC.Bff.HttpAggregator.Gateway.Middleware;
using WebMVC.Bff.HttpAggregator.Gateway.Middleware.HttpMiddleware;
using WebMVC.HttpAggregator.Gateway.Infrastructure;
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
            services.AddResponseCaching();
            services.AddHttpMiddleware(Configuration);
            services.AddHttpContextAccessor();
            services.AddCustomGrpcClientFactoryMiddleware(Configuration);
            services.AddCustomSwagger(Configuration);
            services.AddCustomAssemblies();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));// TODO arvan, et muutub ümber aga pean veel vaatama
            });
            /*var container = new ContainerBuilder();
            container.RegisterModule(new AssemblyModule());//*///
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

            app.UseResponseCaching();
            app.UseHttpsRedirection();
            app.UseStaticFiles();//

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerAPI(Configuration);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapServices(Configuration);
            });
        }
    }
}