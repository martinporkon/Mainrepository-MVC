using Ocelot.DependencyInjection;
using WebMVC.Bff.HttpAggregator.Gateway.HttpHandlers;

// TODO FIX NAMESPACES!!
namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware
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