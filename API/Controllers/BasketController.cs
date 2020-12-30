using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nupp.Views.Home;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/products")]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;

        public BasketController(ILogger<BasketController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post(string id, string type, string name)
        {
            var test2 = name;
            return Ok(test2);
        }
    }
}
