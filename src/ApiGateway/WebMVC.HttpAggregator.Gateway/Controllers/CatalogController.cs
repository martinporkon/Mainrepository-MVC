using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sooduskorv_MVC.Middleware.AuthorizationMiddleware;

namespace WebMVC.HttpAggregator.Gateway.Controllers
{
    [ApiController]
    [Route("api/mvc-bff/catalog")]
    [AllowAnonymous]
    public class CatalogController : ControllerBase
    {
        public CatalogController()
        {

        }
    }
}