using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebMVC.Bff.HttpAggregator.Gateway.Middleware.HealthChecks
{
    public class EventBusHealthCheck : IHealthCheck
    {
        private volatile bool _startupTaskCompleted = false;
        private readonly string _topic;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        public bool StartupTaskCompleted
        {
            get => _startupTaskCompleted;
            set => _startupTaskCompleted = value;
        }

        public EventBusHealthCheck(IConfiguration config, string topic, string connectionString)
        {
            _topic = topic;
            _connectionString = config.GetSection("EventBusConnString:0").ToString();
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            // TODO
            if (StartupTaskCompleted)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("The startup task is finished."));
            }

            return Task.FromResult(
                HealthCheckResult.Unhealthy("The startup task is still running."));
        }
    }
}