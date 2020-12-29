using System.Collections.Generic;
using System.Globalization;

namespace Sooduskorv_MVC.Middleware.Culture
{
    public class CultureSwitcher
    {
        public CultureInfo CurrentUICulture { get; set; }
        public List<CultureInfo> SupportedCultures { get; set; }
    }
}