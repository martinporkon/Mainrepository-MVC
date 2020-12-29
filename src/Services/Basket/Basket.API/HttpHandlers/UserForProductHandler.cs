using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Basket.API.HttpHandlers
{
    /// <summary>
    /// For deleting. Retrieving. Creating. Updating. Baskets. Orders etc.
    /// </summary>
    public class UserForProductHandler : AuthorizationHandler<UserForProductRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserForProductHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            UserForProductRequirement requirement)
        {
            // TODO but not here.
            var basketId = _httpContextAccessor.HttpContext.GetRouteValue("Id").ToString();// TODO
            var buyerId = context.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}