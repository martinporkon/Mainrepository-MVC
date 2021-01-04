using Ocelot.DependencyInjection;

// TODO FIX NAMESPACES!!
namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware
{
    public static class AddCustomDelegatingHandlers
    {
        public static IOcelotBuilder AddDelegatingHandlers(this IOcelotBuilder ocelot)
        {
            /*ocelot.AddDelegatingHandler<TokenExchangeHandler>();
            ocelot.AddDelegatingHandler<IntegrationHandler>();*/
            return ocelot;
        }
    }
}