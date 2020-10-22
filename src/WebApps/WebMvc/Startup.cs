using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Extensions.Http;
using SooduskorvWebMVC.HttpHandlers;
using SooduskorvWebMVC.Middleware;
using SooduskorvWebMVC.PostConfigurationOptions;
using WebMVC.Domain.Services;

namespace SooduskorvWebMVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null)
                .AddRazorRuntimeCompilation();
            services.AddServerSideBlazor();

            services.AddCustomAuthorization(Configuration);
            services.AddHttpContextAccessor();

            services.AddHttpClient<IProductsService, ProductsService>();
            services.AddScoped<IProductsService, ProductsService>();

            services.AddTransient<BearerTokenHandler>();

            services.AddHttpClientServices(Configuration);
            services.AddCustomAuthentication(Configuration);

            services.AddSingleton<IPostConfigureOptions<OpenIdConnectOptions>, OpenIdConnectOptionsPostConfigurationOptions>();

            services.AddServerSideBlazor();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy() => HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(5, TimeSpan.FromSeconds(30));

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapBlazorHub();
            });
        }
    }
}