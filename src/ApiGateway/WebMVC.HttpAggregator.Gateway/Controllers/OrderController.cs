using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.HttpAggregator.Gateway.Controllers
{
    [ApiController]
    [Route("api/mvc-bff/order")]
    [AllowAnonymous]
    public class OrderController : ControllerBase
    {

    }
}