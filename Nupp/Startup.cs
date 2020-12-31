using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nupp.Services;
using Nupp.Views.Home;
using Nupp.Views.Home.Button;
using CatalogItemBase = Nupp.Views.Home.Button.CatalogItemBase;

namespace Nupp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();/*options =>*/
            /*{
                options.RootDirectory = "/Views";
            });#1#*/
            services.AddServerSideBlazor();

            /*services.AddHttpClient("APIClient");*/
            services.AddScoped<ViewState>();
            services.AddScoped<NotifierService>();
            services.AddScoped<CatalogItemState>();
            services.AddScoped<SendBasketItemBase>();
            services.AddScoped<CatalogItemBase>();
            services.AddOptions();
            services.AddSingleton<PageSettings>();
            services.AddHttpClient<IBasketService, BasketService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:5000");
            });
            services.AddResponseCompression(options => { });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            /*app.UseAuthorization();*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                /*endpoints.MapFallbackToPage("/_Host");*/
            });
        }
    }
}
