using System.Reflection;
using Microsoft.Extensions.Localization;

namespace SooduskorvWebMVC.Localization
{
    public class LocalizationService
    {
        private readonly IStringLocalizer _localizer;

        public LocalizationService(IStringLocalizerFactory f)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName ?? string.Empty);
            _localizer = f.Create("SharedResource", assemblyName.Name ?? string.Empty);
        }

        public LocalizedString GetLocalizedHtmlString(string key)
        {
            return _localizer[key];
        }

    }
}