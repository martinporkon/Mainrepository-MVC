using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.HttpAggregator.Gateway.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("")]
    public class CatalogController : ControllerBase
    {
        public CatalogController()
        {
        
        }
    }
}