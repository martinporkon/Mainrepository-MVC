using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebMVC.HttpAggregator.Gateway.Middleware
{
    public static class AddCustomAuthorizationExtensions
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services,
            IConfiguration configuration)
        {
            throw new NotImplementedException();
        }
    }
}