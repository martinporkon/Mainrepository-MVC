using System.Threading.Tasks;
using Grpc.Health.V1;

namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware.HealthChecks.GRpc
{
    public interface IGRpcHealthChecks
    {
        public Task<HealthCheckResponse> GetGRpcHealth(HealthCheckRequest r, string url);
    }
}