using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Sooduskorv_MVC.Common.TagHelpers
{
    public class AuthorizationPolicyTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IAuthorizationService _auth;

        public AuthorizationPolicyTagHelper(
            IHttpContextAccessor httpContext,
            IAuthorizationService auth)
        {
            _httpContext = httpContext;
            _auth = auth;
        }

        [HtmlAttributeName("asp-route-id")]
        public string ResourceId { get; set; }

        [HtmlAttributeName("asp-auth-policy")]
        public string PolicyName { get; set; }

        public override /*async*/ Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            throw new NotImplementedException();
        }
    }
}