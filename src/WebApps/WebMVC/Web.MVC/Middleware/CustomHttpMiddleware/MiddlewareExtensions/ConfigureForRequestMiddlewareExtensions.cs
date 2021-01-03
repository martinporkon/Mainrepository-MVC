using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder
{
    public static class ConfigureForRequestMiddlewareExtensions
    {
        //TODO delete.
        public static IHttpClientBuilder ConfigureForAll(this IHttpClientBuilder builder)
        {
            builder.ConfigureForPrimaryHttpMessageHandler().AddCustomPolicyHandlers();
            return builder;
        }
    }
}