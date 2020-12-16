using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Sooduskorv_MVC.Middleware.LastRequestMiddleware
{
    public class RequestTrackingMiddleware
    {
        // viimane päring mis tehti...kuhugi
        private readonly RequestDelegate _next;
        public RequestTrackingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // TODO. get user. log user. Reset and save values for the User.
            await _next(context);
        }
    }
}