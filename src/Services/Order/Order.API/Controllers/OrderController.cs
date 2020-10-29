using System;
using Microsoft.AspNetCore.Mvc;
using Order.Infra.Order;

namespace Order.API.Controllers
{
    public class OrderController : OrderRepository
    {
        public OrderController()
        {
            
        }
    }
}