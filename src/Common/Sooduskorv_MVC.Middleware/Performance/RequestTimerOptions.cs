using System;
using Microsoft.AspNetCore.Http;

namespace Sooduskorv_MVC.Middleware.RequestMiddleware
{
    public class RequestTimerOptions
    {
        public RequestTimerOptions()
        {
            Format = (ctx, elapsed) => $"Request to {ctx.Request.Path} took {elapsed} ms";
        }
        public Func<HttpContext, long, string> Format { get; set; }
    }
}