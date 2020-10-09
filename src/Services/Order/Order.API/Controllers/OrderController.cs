using System;
using Microsoft.AspNetCore.Mvc;

namespace Order.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController() => throw new NotImplementedException(nameof(OrderController));
    }
}