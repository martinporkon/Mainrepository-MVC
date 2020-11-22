using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace SooduskorvWebMVC.Middleware.CustomizedAutoMapperMiddleware
{
    public static class AddCustomAutoMapperMiddleware
    {
        public static IServiceCollection AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(AutoMapperConfiguration.RegisterMappings());
            return services;
        }
    }
}