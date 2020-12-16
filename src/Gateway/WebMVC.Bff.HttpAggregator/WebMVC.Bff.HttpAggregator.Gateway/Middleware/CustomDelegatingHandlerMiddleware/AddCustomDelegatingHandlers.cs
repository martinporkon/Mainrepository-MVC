using Ocelot.DependencyInjection;
using WebMVC.Bff.HttpAggregator.Gateway.HttpHandlers;

namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware.CustomDelegatingHandlerMiddleware
{
    public static class AddCustomDelegatingHandlers
    {
        public static IOcelotBuilder AddDelegatingHandlers(this IOcelotBuilder ocelot)
        {
            ocelot.AddDelegatingHandler<TokenExchangeHandler>();
            return ocelot;
        }
    }
}