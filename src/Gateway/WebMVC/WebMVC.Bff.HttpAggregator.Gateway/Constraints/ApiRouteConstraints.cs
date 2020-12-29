using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace WebMVC.Bff.HttpAggregator.Gateway.Http
{
    public class ApiRouteConstraints : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            throw new System.NotImplementedException();
        }
    }
}