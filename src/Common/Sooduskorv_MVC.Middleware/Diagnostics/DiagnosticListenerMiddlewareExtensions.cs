using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DiagnosticAdapter;

namespace Sooduskorv_MVC.Middleware.Diagnostics
{
    public static class DiagnosticsMiddlewareExtensions
    {
        public static IApplicationBuilder UseDiagnosticsTracking(this IApplicationBuilder builder)
        {
            var options = new DiagnosticsOptions();
            return builder.UseMiddleware<DiagnosticsMiddleware>(options);
        }

        public static IApplicationBuilder UseDiagnosticsTracking(this IApplicationBuilder builder, Action<DiagnosticsOptions> configuration)
        {
            var options = new DiagnosticsOptions();
            configuration(options);
            return builder.UseMiddleware<DiagnosticsMiddleware>(options);
        }

        /// <summary>
        /// SystemDiagnostics should be the first object.
        /// Add the middleware. // works with many ?
        /// </summary>
        public static IDisposable SubscribeWithAdapter(this DiagnosticListener listener, params object[] targets)
        {
            var diagnosticSourceAdapter = new DiagnosticSourceAdapter(targets);
            return listener.Subscribe(diagnosticSourceAdapter, new Predicate<string>(diagnosticSourceAdapter.IsEnabled));
        }
    }
}