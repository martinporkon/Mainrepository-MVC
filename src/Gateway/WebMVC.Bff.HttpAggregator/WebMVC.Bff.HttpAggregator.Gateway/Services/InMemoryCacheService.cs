using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Hosting;

namespace WebMVC.Bff.HttpAggregator.Gateway.Hosted
{
    public class InMemoryCacheService : BackgroundService
    {
        private readonly IDistributedCache _distributedCache;

        public InMemoryCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}