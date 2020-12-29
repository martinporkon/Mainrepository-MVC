using Microsoft.AspNetCore.Mvc.Filters;

namespace Sooduskorv_MVC.Middleware.Stuff
{
    public class JsonExceptionAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}