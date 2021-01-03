using System.Net;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder
{
    public static class ConfigureForPrimaryHttpMessageHandlerMiddlewareExtensions
    {
        public static IHttpClientBuilder ConfigureForPrimaryHttpMessageHandler(this IHttpClientBuilder builder)
        {
            builder.ConfigurePrimaryHttpMessageHandler(handler =>
                new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.Brotli,
                });
            return builder;
        }
    }
}