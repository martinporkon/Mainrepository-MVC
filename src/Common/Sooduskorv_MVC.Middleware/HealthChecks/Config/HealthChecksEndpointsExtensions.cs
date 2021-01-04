using Grpc.HealthCheck;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Sooduskorv_MVC.Aids.Constants;

namespace Sooduskorv_MVC.Middleware.HealthChecks
{
    public static class HealthChecksEndpointsExtensions
    {
        public static IEndpointRouteBuilder UseCustomHealthChecks(this IEndpointRouteBuilder endpoints, IConfiguration config = null)
        {
            endpoints.MapHealthChecks(HealthCheck.Live, new HealthCheckOptions
            {
                Predicate = _ => false,
                AllowCachingResponses = false,
                /*ResponseWriter = WriteResponse*/
            });
            endpoints.MapHealthChecks(HealthCheck.Ready, new HealthCheckOptions
            {
                AllowCachingResponses = false,
                /*ResponseWriter = WriteResponse*/
            });
            return endpoints;
        }

        public static IEndpointRouteBuilder UseCustomGRpcHealthChecks<THealthService, TDbContext>(this IEndpointRouteBuilder endpoints, IConfiguration config = null)
            where THealthService : BackgroundService
            where TDbContext : DbContext
        {
            endpoints.MapHealthChecks(HealthCheck.Live);
            endpoints.MapGrpcService<HealthServiceImpl>();
            endpoints.MapGrpcService<THealthService>();
            // TODO Can Connect still missing here.
            return endpoints;
        }
    }
}