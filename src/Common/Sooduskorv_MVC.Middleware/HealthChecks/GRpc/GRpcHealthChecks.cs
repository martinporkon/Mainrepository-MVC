using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Health.V1;
using Grpc.Net.Client;
using Serilog;

namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware.HealthChecks.GRpc
{
    public class GRpcHealthChecks : IGRpcHealthChecks
    {
        public async Task<HealthCheckResponse> GetGRpcHealth(HealthCheckRequest r, string url)
        {
            HealthCheckResponse health;
            try
            {
                using var channel = GrpcChannel.ForAddress(url);
                var healthClient = new Health.HealthClient(channel);
                health = await healthClient.CheckAsync(r);
            }
            catch (RpcException e)
            {
                Log.Fatal("FATAL RPC ERROR:", e);
                throw;
            }
            catch (Exception e)
            {
                Log.Fatal("FATAL ERROR:", e);
                throw;
            }

            return health;
        }
    }
}