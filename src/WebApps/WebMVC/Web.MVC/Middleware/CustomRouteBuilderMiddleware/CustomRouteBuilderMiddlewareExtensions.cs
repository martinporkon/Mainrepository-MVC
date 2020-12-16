using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;

namespace Microsoft.AspNetCore.Builder
{
    public static class CustomRouteBuilderMiddlewareExtensions
    {
        public static IEndpointRouteBuilder MapCustomEndpointRouteBuilder(this IEndpointRouteBuilder b, IConfiguration c)
        {
            b.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            return b;
        }
    }
}