using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware.HealthChecks.GRpc
{
    public class GRpcDbContextHealthMiddleware<TDbContext> where TDbContext : DbContext, IMiddleware
    {
        private readonly IGRpcHealthChecks _ghc;

        public GRpcDbContextHealthMiddleware(IGRpcHealthChecks ghc)
        {
            _ghc = ghc;
        }
        
        // TODO CanConnect()
    }
}