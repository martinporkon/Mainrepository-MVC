using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Sooduskorv_MVC.Middleware.Culture;
using Sooduskorv_MVC.Middleware.Session;
using SooduskorvWebMVC.ComponentBases;
using SooduskorvWebMVC.HttpHandlers;
using SooduskorvWebMVC.Localization;
using SooduskorvWebMVC.Middleware;
using WebMVC.Facade.Profiles;

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
            /*RateLimit.ConfigureServices(services, Configuration);*/
            /*services.AddMemoryCache();*/
            services.AddSingleton<LocalizationService>();
            services.ConfigureRequestLocalization(Configuration);
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddRazorPages()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName ?? string.Empty);
                        return factory.Create("SharedResource", assemblyName.Name ?? string.Empty);
                    };
                })
                .AddSessionStateTempDataProvider();
            services.AddServerSideBlazor();
            services.AddCustomAuthorization(Configuration);
            services.AddHttpContextAccessor();
            /*services.AddHttpClient<IProductsService, ProductsService>();
            services.AddScoped<IProductsService, ProductsService>();*/
            services.AddScoped<RequestLocalizationMiddleware>();
            services.AddTransient<BearerTokenHandler>();
            services.AddHttpClientServices(Configuration);
            services.AddCustomAuthentication(Configuration);
            services.AddCustomSessions(Configuration);
            // TODO temporary
            services.AddHttpClient<IBasketService, BasketService>(config =>
            {
                config.BaseAddress = new Uri("http://localhost:5000");
            });

            services.AddAutoMapper(AutoMapperConfiguration.RegisterMappings());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<RequestLocalizationOptions>
            rlo)
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

            /*app.UseStatusCodePages("text/plain", "Status Code; {0}. Contact support.");*/
            app.UseHttpsRedirection();
            /*app.UseIpRateLimiting();*/
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseRequestLocalization().WithCookies();
            app.UseCookiePolicy();
            /*app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
                    ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers",
                        "Origin, X-Requested-With, Content-Type, Accept");
                },

            });*/
            app.UseRouting();
            /*app.UseAuthentication();
            app.UseAuthorization();*/
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapCustomEndpointRouteBuilder(Configuration, rlo);// TODO
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                /*endpoints.MapFallbackToPage("/_Host");*/
            });
        }
    }
}