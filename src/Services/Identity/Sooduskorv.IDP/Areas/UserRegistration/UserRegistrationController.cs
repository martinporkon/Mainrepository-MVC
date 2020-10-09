using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Identity.Data.Entities;
using Identity.Domain.Services;
using Identity.Facade.Models;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;

namespace Sooduskorv.IDP.Areas.UserRegistration
{
    public class UserRegistrationController : Controller
    {
        private readonly ILocalUserService _localUserService;

        public UserRegistrationController(
            ILocalUserService localUserService)
        {
            _localUserService = localUserService ??
                throw new ArgumentNullException(nameof(localUserService));
        }

        [HttpGet]
        public IActionResult RegisterUser(string returnUrl) => View(new RegisterUserViewModel { ReturnUrl = returnUrl });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var userToCreate = new UserData()
            {
                Username = model.UserName,
                Subject = Guid.NewGuid().ToString(),
                Email = model.Email,
                Active = false
            };

            userToCreate.Claims.Add(new UserClaim()
            {
                Type = JwtClaimTypes.Address,
                Value = model.Address
            });
            userToCreate.Claims.Add(new UserClaim()
            {
                Type = JwtClaimTypes.GivenName,
                Value = model.GivenName
            });
            userToCreate.Claims.Add(new UserClaim()
            {
                Type = JwtClaimTypes.FamilyName,
                Value = model.FamilyName
            });

            _localUserService.AddUser(userToCreate, model.Password);
            await _localUserService.SaveChangesAsync();

            var link = Url.ActionLink("ActivateUser", "UserRegistration",
                new { securityCode = userToCreate.SecurityCode });


            Debug.WriteLine(link);

            return View("ActivationCodeSent");
        }

        [HttpGet]
        public async Task<IActionResult> ActivateUser(string securityCode)
        {
            if (await _localUserService.ActivateUser(securityCode))
            {
                ViewData["Message"] = "Your account was successfully activated. " +
                                      "Navigate to your client application to log in.";
            }
            else
            {
                ViewData["Message"] = "Your account was not successfully activated, " +
                                      "please contact your administrator.";
            }

            await _localUserService.SaveChangesAsync();

            return View();
        }
    }
}