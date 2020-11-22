using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Sooduskorv_MVC.Middleware.RequestMiddleware;

namespace Sooduskorv_MVC.Middleware.Performance
{
    public class RequestTimerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RequestTimerOptions _options;
        private readonly ILogger<RequestTimerMiddleware> _logger;

        public RequestTimerMiddleware(RequestDelegate next, RequestTimerOptions options, ILogger<RequestTimerMiddleware> logger)
        {
            _next = next;
            _options = options;
            _logger = logger;
        }// TODO path handling for api required in order for this to work properly

        public async Task Invoke(HttpContext ctx)
        {
            var timer = new Stopwatch();
            timer.Start();
            using (_logger.BeginScope("Constructing logger scope for Request Middleware"))
            {
                await _next(ctx);

                timer.Stop();
                _logger.LogInformation(_options.Format(ctx, timer.ElapsedMilliseconds));
            }
        }
    }
}