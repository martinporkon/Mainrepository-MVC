using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.HttpAggregator.Gateway.Controllers
{
    [ApiController]
    [Route("api/mvc-bff/catalog")]
    [AllowAnonymous]
    public class CatalogController : ControllerBase
    {

    }
}