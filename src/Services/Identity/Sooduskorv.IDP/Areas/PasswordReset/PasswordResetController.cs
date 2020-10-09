using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Identity.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Sooduskorv.IDP.Areas.PasswordReset
{
    public class PasswordResetController : Controller
    {
        private readonly ILocalUserService _localUserService;

        public PasswordResetController(
            ILocalUserService localUserService)
        {
            _localUserService = localUserService ??
                                throw new ArgumentNullException(nameof(localUserService));
        }

        [HttpGet]
        public IActionResult RequestPassword() => View(new RequestPassword());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestPassword(RequestPassword model)
        {
            if (!ModelState.IsValid) return View(model);

            var securityCode = await _localUserService
                .InitiatePasswordResetRequest(model.Email);
            await _localUserService.SaveChangesAsync();
            var link = Url.ActionLink("ResetPassword", "PasswordReset", new { securityCode });
            Debug.WriteLine(link);

            return View("PasswordResetRequestSent");
        }

        [HttpGet]
        public IActionResult ResetPassword(string securityCode) => View(new ResetPassword { SecurityCode = securityCode });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPassword model)
        {
            if (!ModelState.IsValid) return View(model);

            if (await _localUserService.SetPassword(model.SecurityCode, model.Password))
            {
                ViewData["Message"] = "Your password was successfully changed.  " +
                                      "Navigate to your client application to log in.";
            }
            else
            {
                ViewData["Message"] = "Your password couldn't be changed, please" +
                                      " contact your administrator.";
            }

            await _localUserService.SaveChangesAsync();

            return View("ResetPasswordResult");
        }
    }
}