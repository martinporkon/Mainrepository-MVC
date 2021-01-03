using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder
{
    public static class AddCustomControllersWithViewsMiddlewareExtensions
    {
        public static IServiceCollection AddCustomControllersWithViews(this IServiceCollection services)
        {
            services.AddControllersWithViews(configure =>
                {
                    configure.RespectBrowserAcceptHeader = true;
                })
                .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null)
                .AddRazorRuntimeCompilation();
            return services;
        }
    }
}