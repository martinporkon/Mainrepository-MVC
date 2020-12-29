using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Sooduskorv_MVC.Aids.Constants;
using Sooduskorv_MVC.Middleware.Culture;
using Sooduskorv_MVC.Middleware.Session;
using SooduskorvWebMVC.HttpHandlers;
using SooduskorvWebMVC.Middleware;
using SooduskorvWebMVC.PostConfigurationOptions;

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
            services.AddLocalization(options => options.ResourcesPath = Localization.DefaultPath);
            services.ConfigureRequestLocalization(Configuration);
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddRazorPages()
                .AddViewLocalization().AddSessionStateTempDataProvider();
            services.AddCustomControllersWithViews();
            services.AddServerSideBlazor();
            services.AddCustomAuthorization(Configuration);
            services.AddHttpContextAccessor();// vist saab eemaldada. Juba olemas.
            /*services.AddHttpClient<IProductsService, ProductsService>();
            services.AddScoped<IProductsService, ProductsService>();*/
            services.AddTransient<BearerTokenHandler>();
            services.AddHttpClientServices(Configuration);
            services.AddCustomAuthentication(Configuration);
            services.AddSingleton<IPostConfigureOptions<OpenIdConnectOptions>, OpenIdConnectOptionsPostConfigurationOptions>();
            /*services.AddCustomSessions(Configuration);*/
            services.AddScoped<RequestLocalizationMiddleware>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<RequestLocalizationOptions>
            rlo)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            /*app.UseStatusCodePages("text/plain", "Status Code; {0}. Contact support.");*/
            app.UseHttpsRedirection();
            /*app.UseIpRateLimiting();*/
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapCustomEndpointRouteBuilder(Configuration, rlo);// TODO
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                /*endpoints.MapFallbackToPage("/.....");*/
            });
        }
    }
}