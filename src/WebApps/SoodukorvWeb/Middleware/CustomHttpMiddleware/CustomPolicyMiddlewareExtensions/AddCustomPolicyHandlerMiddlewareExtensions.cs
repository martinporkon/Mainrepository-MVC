using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace Microsoft.AspNetCore.Builder
{
    public static class AddCustomPolicyHandlerMiddlewareExtensions
    {
        public static IHttpClientBuilder AddCustomPolicyHandlers(this IHttpClientBuilder builder)
            => builder
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(GetCircuitBreakerPolicy());

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy() => HttpPolicyExtensions
        .HandleTransientHttpError()
        .WaitAndRetryAsync(5,
            retryAttempt => TimeSpan.FromMilliseconds(Math.Pow(1.5, retryAttempt) * 1000),
            (_, waitingTime) =>
            {
                Log.Exception(new Exception());
            });

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy() => HttpPolicyExtensions
            .HandleTransientHttpError()
            .CircuitBreakerAsync(3, TimeSpan.FromSeconds(30));
    }
}