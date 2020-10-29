using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.AccessTokenValidation;

namespace Sooduskorv_MVC.Middleware.AuthorizationMiddleware
{
    public class CustomIdentityServerAuthenticationOptions
    {
        public Action<IdentityServerAuthenticationOptions> configureOptions { get; set; }
    }
}