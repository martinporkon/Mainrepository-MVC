using System;
using System.Net;
using Catalog.API.Data;
using Catalog.API.HttpHandlers;
using Catalog.API.Middleware;
using Catalog.Infra;
using Catalog.Infra.Catalog;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Catalog.API
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
            services.AddCustomSwagger(Configuration);
            services.AddHttpContextAccessor();
            services.AddOptions();
            services.AddScoped<ICatalogRepository, CatalogRepository>();// TODO
            services.AddScoped<IAuthorizationHandler, SubjectMustMatchUserHandler>();

            services.AddCustomAuthorization(Configuration);

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:44318";
                    options.ApiName = "productsapi";
                    options.ApiSecret = "apisecret";
                });
            services.AddDbContext<CatalogApplicationDbContext>(options =>// TODO !!!!
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddDbContext<CatalogDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>// TODO
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                    });
                });
                app.UseHsts();
            }

            /*app.UseApiExceptionHandler(options => //uncomment if the app is functional
            {
                options.AddResponseDetails = UpdateApiErrorResponse;
                options.DetermineLogLevel = DetermineLogLevel;
            });*/

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerAPI(Configuration);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static LogLevel DetermineLogLevel(Exception ex)
        {
            if (ex.Message.StartsWith("cannot open database", StringComparison.InvariantCultureIgnoreCase)
                || ex.Message.StartsWith("a network-related", StringComparison.InvariantCultureIgnoreCase))
            {
                return LogLevel.Critical;
            }

            return LogLevel.Error;
        }

        public static void UpdateApiErrorResponse(HttpContext context, Exception ex, ApiError error)
        {
            if (ex.GetType().Name is nameof(SqlException))
            {
                error.Detail = "Exception was a database exception!";
                error.Links = "https://andmebaas.com/andmebaasi.exception";
                error.StatusCode = HttpStatusCode.InternalServerError.ToString();// TODO
            }
        }
    }
}