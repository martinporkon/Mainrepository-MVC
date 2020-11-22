using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Basket.Facade.Baskets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Bff.HttpAggregator.Domain.BasketService.CommandRequests;
using WebMVC.Bff.HttpAggregator.Domain.CurrentService.CurrentServiceQuery;
using WebMVC.Bff.HttpAggregator.Domain.CurrentService.Entities;
using WebMVC.Bff.HttpAggregator.Infra.Common;
using WebMVC.HttpAggregator.Domain.BasketService.QueryHandlers;
using WebMVC.HttpAggregator.Domain.BasketService.QueryRequests;

namespace WebMVC.HttpAggregator.Gateway.Controllers
{
    [ApiController]
    [Route("api/mvc-bff/baskets")]
    [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IQueryHandler<PictureQuery, Resource> _queryHandler;

        public BasketController(IMediator mediator, IQueryHandler<PictureQuery, Resource> queryHandler)
        {
            _mediator = mediator;
            _queryHandler = queryHandler;
        }

        [Route("{basketId}")]
        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<BasketView>>> GetBasket([FromRoute] GetUserBasketByIdQuery query) // + userId
        {
            var result = await _mediator.Send(new GetUserBasketByIdQueryHandler(_queryHandler));
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
            var result = await _mediator.Send(new GetUserBasketsQueryHandler());
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPatch]
        public async Task<ActionResult> UpdateBasket([FromBody] UpdateBasketCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpOptions]
        public ActionResult GetBasketOptions()
        {
            Response.Headers.Add("Allowed-Methods", "GET, OPTIONS, PATCH");
            return Ok();
        }
    }
}