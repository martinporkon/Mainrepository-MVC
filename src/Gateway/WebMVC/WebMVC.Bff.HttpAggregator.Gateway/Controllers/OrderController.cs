using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Bff.HttpAggregator.Gateway.Controllers
{
    [ApiController]
    [Route("api/mvc-bff/orders")]
    [Authorize]
    public class OrderController : ControllerBase // + userId
    {
        public OrderController() => throw new NotImplementedException();
    }
}