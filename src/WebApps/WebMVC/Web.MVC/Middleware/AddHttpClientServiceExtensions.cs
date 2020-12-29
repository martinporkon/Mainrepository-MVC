using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using SooduskorvWebMVC.HttpHandlers;

namespace SooduskorvWebMVC.Middleware
{
    public static class AddHttpClientServiceExtensions
    {
        public static IServiceCollection AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("APIClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:44366/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            }).ConfigureForAll().AddUserAccessTokenHandler();// TODO the Token Handler.
            services.AddHttpClient("TokenAPIClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:44366/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            }).AddHttpMessageHandler<BearerTokenHandler>().AddUserAccessTokenHandler();
            services.AddHttpClient("IDPClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:44318/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            }).AddUserAccessTokenHandler();

            /*services.AddHttpClient<IInterface, Service>(client =>
            {
                  client.BaseAddress = new Uri("https://localhost:44340/");
            });*/

            return services;
        }
    }
}