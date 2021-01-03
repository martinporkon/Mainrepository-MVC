using Microsoft.Extensions.DependencyInjection;
using WebMVC.Bff.HttpAggregator.Gateway.HttpHandlers;

namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware
{
    public static class Register
    {
        public static void Services(IServiceCollection s)
        {
            s.AddScoped<TokenExchangeHandler>();
        }
    }
}