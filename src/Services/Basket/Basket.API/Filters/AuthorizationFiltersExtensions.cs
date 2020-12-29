using System;
using System.Net;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace Basket.API.Filters
{
    public static class AuthorizationFiltersExtensions
    {// TODO MASSIVE
        /// <summary>
        /// For authorizing an entire endpoint based on a selected policy.
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="policyName"></param>
        /// <returns></returns>
        public static AuthorizeFilter AuthorizeFor(this Authorization auth, string policyName)
        {
            // TODO check if policy is not null and exists
            var foo = new AuthorizeFilter(policyName);// TODO
            return foo;
        }
        // TODO
        /// <summary>
        /// For authorizing an entire endpoint based on multiple policies. Needs work though.
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="policyName"></param>
        /// <returns></returns>
        public static AuthorizeFilter AuthorizeFor(this Authorization[] auth, string policyName)// ?
        {
            throw new NotImplementedException();
        }
    }
}