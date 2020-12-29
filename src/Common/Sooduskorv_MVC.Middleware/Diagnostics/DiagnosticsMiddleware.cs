using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Sooduskorv_MVC.Middleware.Diagnostics
{
    public class DiagnosticsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly DiagnosticSource _diagnostics;

        public DiagnosticsMiddleware(RequestDelegate next, DiagnosticSource diagnosticSource)
        {
            _next = next;
            _diagnostics = diagnosticSource;
        }

        public async Task Invoke(HttpContext context)
        {
            if (_diagnostics.IsEnabled("SystemDiagnostics.MiddlewareStarting"))
            {
                _diagnostics.Write("SystemDiagnostics.MiddlewareStarting",// TODO Validate strings
                    // and check if working.
                    new
                    {
                        httpContext = context
                    });
            }

            await _next.Invoke(context);
        }
    }
}