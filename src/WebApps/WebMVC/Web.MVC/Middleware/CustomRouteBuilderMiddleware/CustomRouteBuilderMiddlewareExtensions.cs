using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Builder
{
    public static class CustomRouteBuilderMiddlewareExtensions
    {
        public static IEndpointRouteBuilder MapCustomEndpointRouteBuilder(this IEndpointRouteBuilder b, IConfiguration c,
            IOptions<RequestLocalizationOptions> rlo)
        {
            b.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            /*b.MapControllerRoute(
                name: "localizedDefault",
                pattern: "{culture:culture}/{controller=Home}/{action=Index}/{id?}",
                defaults: new { culture = rlo.Value.DefaultRequestCulture.Culture.Name });*/

            return b;
        }
    }
}