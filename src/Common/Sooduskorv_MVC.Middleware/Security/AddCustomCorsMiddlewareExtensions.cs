﻿using AspNetCoreRateLimit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sooduskorv_MVC.Middleware.SecurityMiddleware
{
    public static class AddCustomIpRateLimitingMiddleware
    {
        public static IServiceCollection AddCustomRateLimiting(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddOptions();
            services.AddMemoryCache();
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
            services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            return services;
        }
    }
}
// # This goes to the configuration file to apply.
//"IpRateLimiting": {
//  "EnableEndpointRateLimiting": false,
//  "StackBlockedRequests": false,
//  "RealIpHeader": "X-Real-IP",
//  "ClientIdHeader": "X-ClientId",
//  "HttpStatusCode": 429,
//  "IpWhitelist": [ "127.0.0.1", "::1/10", "192.168.0.0/24" ],
//  "EndpointWhitelist": [ "get:/api/license", "*:/api/status" ],
//  "ClientWhitelist": [ "dev-id-1", "dev-id-2" ],
//  "GeneralRules": [
//    {
//      "Endpoint": "*",
//      "Period": "1s",
//      "Limit": 2
//    },
//    {
//      "Endpoint": "*",
//      "Period": "15m",
//      "Limit": 100
//    },
//    {
//      "Endpoint": "*",
//      "Period": "12h",
//      "Limit": 1000
//    },
//    {
//      "Endpoint": "*",
//      "Period": "7d",
//      "Limit": 10000
//    }
//  ]
//}