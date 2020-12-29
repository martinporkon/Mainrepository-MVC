using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

namespace Sooduskorv_MVC.Middleware.Culture
{
    public class CultureProviderResolverService : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            throw new System.NotImplementedException();
        }
    }
}