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
        /*public static IApplicationBuilder UseCultureForRequestLocalization(this IApplicationBuilder app, IConfiguration config)
        {
            var supportedCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            /*var supportedCultures = new[]
            {// Add the culture of choosing.
                new CultureInfo("en"),
                new CultureInfo("de"),
                new CultureInfo("fr"),
                new CultureInfo("es"),
                new CultureInfo("ru"),
                new CultureInfo("ja"),
                new CultureInfo("ar"),
                new CultureInfo("zh"),
                new CultureInfo("en-GB")
            };#1#
            var l = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(UseCulture.EnglishUs),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            l.RequestCultureProviders.Clear();
            l.RequestCultureProviders.Add(new CultureProviderResolverService());
            app.UseRequestLocalization(l);
            return app;
        }*/

        /// <summary>
        /// Sooduskorv custom request localization service.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureRequestLocalization(this IServiceCollection services, IConfiguration config)
        {
            services.AddLocalization(options => options.ResourcesPath = Localization.DefaultPath);
            var supportedCultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var l = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(UseCulture.EnglishUs),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            /*l.AddSupportedUICultures("de-DE","en-US", "en-GB");*/
            /*l.FallBackToParentUICultures = true;*/
            l.RequestCultureProviders.Clear();
            //l.RequestCultureProviders.Add(new CultureProviderResolverService());// Tahaksin teha varsti seda <<--
            l.RequestCultureProviders.Remove(typeof(AcceptLanguageHeaderRequestCultureProvider));// Praegu prooviks niimoodi. <<--
            return services;
        }
    }
}
/*var supportedCultures = new[]
{// Add the culture of choosing.
    new CultureInfo("en"),
    new CultureInfo("de"),
    new CultureInfo("fr"),
    new CultureInfo("es"),
    new CultureInfo("ru"),
    new CultureInfo("ja"),
    new CultureInfo("ar"),
    new CultureInfo("zh"),
    new CultureInfo("en-GB")
};*/