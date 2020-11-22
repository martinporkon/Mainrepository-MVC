using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.HttpAggregator.Facade.DTO;
using WebMVC.HttpAggregator.Infra.Basket.Queries;

namespace WebMVC.HttpAggregator.Gateway.Controllers
{
    [ApiController]
    [Route("api/mvc-bff/baskets")]
    [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("{basketId}")]
        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<BasketView>>> GetBasket([FromRoute] string basketId) // + userId
        {
            // Kasutada mingisuguseid Delegaate Selles API pooles. Mis suudavad edasi enda terve
            // päringu repositooriumist.
            var result = await _mediator.Send(new GetUserBasketsQuery("id"));

            // RequestDelegate kasutada.
            return result != null ? (ActionResult<IEnumerable<BasketView>>)Ok(new BasketView()) : NotFound();
        }

        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<BasketView>>> GetBaskets()// + userId
        {
            // Kasutada mingisuguseid Delegaate Selles API pooles. Mis suudavad edasi enda terve
            // päringu repositooriumist.
            var result = await _mediator.Send(new GetUserBasketsQuery("id"));

            // RequestDelegate kasutada.
            return result != null ? (ActionResult<IEnumerable<BasketView>>)Ok(new BasketView()) : NotFound();
        }














    }










}