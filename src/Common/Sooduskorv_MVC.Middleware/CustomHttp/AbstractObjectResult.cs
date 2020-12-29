using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Sooduskorv_MVC.Middleware.CustomHttpMiddleware
{
    public abstract class AbstractObjectResult : IActionResult
    {
        protected AbstractObjectResult()
        {

        }
        public virtual Task ExecuteResultAsync(ActionContext context)
        {
            throw new NotImplementedException();
        }
    }
}