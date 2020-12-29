using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Sooduskorv_MVC.Middleware.Stuff
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AutoMapAttribute : ActionFilterAttribute
    {
        public AutoMapAttribute(Type sourceType, Type destType)
        {
            SourceType = sourceType;
            DestType = destType;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext) { }

        public Type SourceType { get; }

        public Type DestType { get; }
    }
}