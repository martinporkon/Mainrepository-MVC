using Identity.Domain.Services;
using Identity.Infra.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sooduskorv.IDP.Data;
using Sooduskorv_MVC.Aids.Reflection;
using Sooduskorv_MVC.Middleware;

namespace Sooduskorv.IDP
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }
        private ICertificateAccessor Accessor { get; }

        public Startup(IWebHostEnvironment e, IConfiguration c/*, ICertificateAccessor a*/)
        {
            /*Accessor = a;*/
            Environment = e;
            Configuration = c;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<ILocalUserService, LocalUserService>();
            var assembly = GetClass.assemblyName<Startup>();
            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiResources(Config.ApiResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients);
            /*.AddCustomConfigurationStore(assembly)
            .AddCustomOperationalStore(assembly);*/

            builder.AddProfileService<LocalUserProfileService>();

            builder.AddDeveloperSigningCredential();
            /*builder.AddSigningCredential(Accessor.LoadCertificate(Configuration));*/

            services.AddDbContext<ApplicationDbContext>(options => // TODO !!!
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocaldb;Database=CustomerDB;Trusted_Connection=True;");
            });
            services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            // TODO else
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}