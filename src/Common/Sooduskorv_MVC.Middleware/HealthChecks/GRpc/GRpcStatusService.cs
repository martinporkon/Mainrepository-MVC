using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Health.V1;
using Grpc.HealthCheck;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace Sooduskorv_MVC.Middleware.HealthChecks
{
    public class GRpcStatusService : BackgroundService
    {
        private readonly HealthServiceImpl _healthService;
        private readonly HealthCheckService _healthCheckService;
        private readonly IConfiguration _config;

        public GRpcStatusService(HealthServiceImpl healthService, HealthCheckService healthCheckService,
            IConfiguration config)
        {
            _healthService = healthService;
            _healthCheckService = healthCheckService;
            _config = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var health = await _healthCheckService.CheckHealthAsync(stoppingToken);

                _healthService.SetStatus(_config.GetSection("HealthChecksServiceInfo:0").ToString(),
                    health.Status == HealthStatus.Healthy
                        ? HealthCheckResponse.Types.ServingStatus.Serving
                        : HealthCheckResponse.Types.ServingStatus.NotServing);

                _healthService.SetStatus(string.Empty,
                    health.Status == HealthStatus.Healthy
                        ? HealthCheckResponse.Types.ServingStatus.Serving
                        : HealthCheckResponse.Types.ServingStatus.NotServing);

                await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);
            }
        }
    }
}