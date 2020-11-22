using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.HttpAggregator.Gateway.Controllers
{
    [ApiController]
    [Route("api/mvc-bff/order")]
    [Authorize]
    public class OrderController : ControllerBase
    {
        public OrderController() => throw new NotImplementedException();
    }
}