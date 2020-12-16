using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace WebMVC.Bff.HttpAggregator.Core.User
{
    public class CurrentUserAccessor : ICurrentUserAccessor
    {
        private readonly HttpContext _httpContext;
        public string UserId
            => _httpContext.User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value;// throw

        public CurrentUserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }
    }
}