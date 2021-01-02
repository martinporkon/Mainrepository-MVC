using System;
using System.Linq;
using Catalog.Data.UserProfiles;
using Catalog.Infra.Catalog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    //[Route("api/catalog/applicationuserprofiles")]// TODO
    //[ApiController]
    ///*[Authorize]*/
    //public class UserProfilesController : ControllerBase
    //{
    //    private readonly ICatalogRepository _catalogRepository;

    //    public UserProfilesController(
    //        ICatalogRepository catalogRepository)
    //    {
    //        _catalogRepository = catalogRepository ??
    //                             throw new ArgumentNullException(nameof(catalogRepository));
    //    }

    //    [HttpGet("{subject}")]
    //    [Authorize(Policy = "SubjectMustMatchUser")]
    //    public IActionResult GetApplicationUserProfile(string subject)
    //    {
    //        var applicationUserProfileFromRepo = _catalogRepository.GetApplicationUserProfile(subject);

    //        if (applicationUserProfileFromRepo == null)
    //        {
    //            var subjectFromToken = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

    //            applicationUserProfileFromRepo = new UserProfileData()
    //            {
    //                Subject = subject,
    //                SubscriptionLevel = "FreeUser"
    //            };

    //            _catalogRepository.AddApplicationUserProfile(applicationUserProfileFromRepo);
    //            _catalogRepository.Save();
    //        }
    //        return Ok(applicationUserProfileFromRepo);
    //    }
    //}
}