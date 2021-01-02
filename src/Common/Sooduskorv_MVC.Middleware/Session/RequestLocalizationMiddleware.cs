using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace Sooduskorv_MVC.Middleware.Session
{
    public class RequestLocalizationMiddleware : IMiddleware
    {
        public CookieRequestCultureProvider Provider { get; }
        public RequestLocalizationMiddleware(IOptions<RequestLocalizationOptions> rlo)
            => Provider = rlo.Value.RequestCultureProviders
                .Where(x => x is CookieRequestCultureProvider)
                    .Cast<CookieRequestCultureProvider>()
                    .FirstOrDefault();

        private void DetermineRequestCultureSaving(HttpContext ctx)
        {
            var feature = ctx.Features.Get<IRequestCultureFeature>();
            if (feature != null)
                ctx.Response
                    .Cookies
                    .Append(
                        Provider.CookieName,
                        CookieRequestCultureProvider.MakeCookieValue(feature.RequestCulture)
                    );
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (Provider != null)
                DetermineRequestCultureSaving(context);
            await next(context);
        }
    }
}