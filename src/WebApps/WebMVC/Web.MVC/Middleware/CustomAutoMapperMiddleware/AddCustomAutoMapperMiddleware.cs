using System;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder
{
    public static class AddCustomAutoMapperMiddleware
    {
        public static IServiceCollection AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            /*services.AddAutoMapper(AutoMapperConfiguration.RegisterMappings());*/
            return services;
        }
    }
}