using System;
using IdentityServer4.AccessTokenValidation;

namespace Sooduskorv_MVC.Middleware.AuthenticationMiddleware
{
    public class CustomIdentityServerAuthenticationOptions
    {
        public Action<IdentityServerAuthenticationOptions> configureOptions { get; set; }
    }
}