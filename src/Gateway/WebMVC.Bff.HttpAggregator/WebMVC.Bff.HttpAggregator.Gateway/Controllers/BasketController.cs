using System.Collections.Generic;
using System.Threading.Tasks;
using Basket.Facade.Baskets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.HttpAggregator.Domain.BasketService.QueryHandlers;

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
        public async Task<ActionResult<IEnumerable<BasketView>>> GetBasket([FromRoute] GetUSer) // + userId
        {
            var result = await _mediator.Send(new GetUserBasketByIdQueryHandler(basketId));
            if (result is null)
            {
                return NotFound();
            }

            return Ok(new BasketView());
        }

        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<BasketView>>> GetBaskets()// + userId
        {
            var result = await _mediator.Send(new GetUserBasketByIdQueryHandler("id"));
            return result != null ? (ActionResult<IEnumerable<BasketView>>)Ok(new BasketView()) : NotFound();
        }
    }
}