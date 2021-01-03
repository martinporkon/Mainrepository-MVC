using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sooduskorv_MVC.Aids.Constants;
using Sooduskorv_MVC.Aids.Extensions;
using Sooduskorv_MVC.Aids.Regions;

namespace Sooduskorv_MVC.Middleware.Culture
{
    public static class UseCultureMiddlewareExtensions
    {
        public static IServiceCollection ConfigureRequestLocalization(this IServiceCollection services, IConfiguration config)
        {
            services.AddLocalization(options => options.ResourcesPath = Localization.DefaultPath);
            /*var supportedCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);*/
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.SetDefaultCulture("et-EE");
                //https://static.visitestonia.com/docs/3371896_tourism-in-estonia-2018.pdf
                options.AddSupportedUICultures("fi-FI", "ja-JP", "de-DE", "en-US", "et-EE", "en-GB", "ru-RU");
                options.FallBackToParentUICultures = true;
                options.RequestCultureProviders.Remove(
                    typeof(AcceptLanguageHeaderRequestCultureProvider));
            });
            /*l.RequestCultureProviders.Clear();*/
            //l.RequestCultureProviders.Add(new CultureProviderResolverService());
            return services;
        }
    }
}