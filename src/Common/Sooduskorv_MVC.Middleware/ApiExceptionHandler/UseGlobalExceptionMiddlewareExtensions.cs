/*using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Sooduskorv_MVC.Middleware.ApiExceptionMiddleware
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }

    public static class UseGlobalExceptionMiddlewareExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app, ILogger logger,
            IConfiguration configuration)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    logger.LogInformation("Catalog.API ERROR MESSAGE:" + $" \"{context.Response.StatusCode}\"");
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {

                        logger.LogError($"Catalog.API Exception: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "An unexpected fault happened. Internal server error."
                        }.ToString());
                    }
                });
            });
        }
    }
}*/