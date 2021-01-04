using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace SooduskorvWebMVC.Controllers
{
    [AllowAnonymous]
    public class PrivacyController : Controller
    {
        public RedirectResult OnGet()
        {
            return Redirect("./Privacy");// Not working at the moment
        }

        public IActionResult OnPostWithdraw()
        {
            HttpContext.Features.Get<ITrackingConsentFeature>().WithdrawConsent();
            return RedirectToPage("./Index");
        }
    }
}