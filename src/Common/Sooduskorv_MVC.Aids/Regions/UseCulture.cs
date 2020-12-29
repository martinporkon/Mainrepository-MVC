using System.Globalization;

namespace Sooduskorv_MVC.Aids.Regions
{

    public class UseCulture {

        public static CultureInfo Current => CultureInfo.CurrentCulture;
 
        public static CultureInfo English => new CultureInfo("en-GB");

        public static CultureInfo EnglishUs => new CultureInfo("en-US");
        
        public static CultureInfo Invariant => CultureInfo.InvariantCulture;

    }

}