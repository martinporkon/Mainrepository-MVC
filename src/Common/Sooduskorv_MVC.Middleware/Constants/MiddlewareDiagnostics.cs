namespace Sooduskorv_MVC.Middleware.Constants
{
    public static class MiddlewareDiagnostics
    {
        public static string Starting => "Microsoft.AspNetCore.MiddlewareAnalysis.MiddlewareStarting";
        public static string Exception => "Microsoft.AspNetCore.MiddlewareAnalysis.MiddlewareException";
        public static string Finished => "Microsoft.AspNetCore.MiddlewareAnalysis.MiddlewareFinished";
        public static string SystemStarting => "SystemDiagnostics.MiddlewareStarting";
    }
}