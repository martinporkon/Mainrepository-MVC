using System;
using Microsoft.AspNetCore.Http;

namespace Sooduskorv_MVC.Middleware.SystemDiagnostics
{
    /// <summary>
    /// TODO must do this for every other service.
    /// Write concrete implementations for the service.
    /// </summary>
    public class BasketSystemDiagnosticsListener : SystemDiagnostics
    {
        public override void OnMiddlewareFinished(HttpContext httpContext, string name)
        {
            base.OnMiddlewareFinished(httpContext, name);
        }
        public override void OnMiddlewareStarting(HttpContext httpContext, string name)
        {
            base.OnMiddlewareStarting(httpContext, name);
        }
        public override void OnMiddlewareException(Exception exception, string name)
        {
            base.OnMiddlewareException(exception, name);
        }
    }
}