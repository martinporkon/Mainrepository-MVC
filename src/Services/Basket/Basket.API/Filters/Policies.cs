using Microsoft.AspNetCore.Authorization;

namespace Basket.API.Filters
{
    public static class Policies
    {
        public static AuthorizationPolicy MyPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("name", "Bob")
                .Build();
        }
    }
}