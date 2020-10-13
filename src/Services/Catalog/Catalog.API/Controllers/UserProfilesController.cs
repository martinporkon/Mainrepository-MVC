using System;
using System.Linq;
using Catalog.Data.UserProfiles;
using Catalog.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/applicationuserprofiles")]
    [ApiController]
    [Authorize]
    public class UserProfilesController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;

        public UserProfilesController(
            IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository ??
                                  throw new ArgumentNullException(nameof(productsRepository));
        }

        [HttpGet("{subject}")]
        [Authorize(Policy = "SubjectMustMatchUser")]
        public IActionResult GetApplicationUserProfile(string subject)
        {
            var applicationUserProfileFromRepo = _productsRepository.GetApplicationUserProfile(subject);

            if (applicationUserProfileFromRepo == null)
            {
                var subjectFromToken = User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;

                applicationUserProfileFromRepo = new UserProfileData()
                {
                    Subject = subject,
                    SubscriptionLevel = "FreeUser"
                };

                _productsRepository.AddApplicationUserProfile(applicationUserProfileFromRepo);
                _productsRepository.Save();
            }
            return Ok(applicationUserProfileFromRepo);
        }
    }
}