using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Basket.Facade.Baskets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Bff.HttpAggregator.Domain.BasketService.CommandRequests;
using WebMVC.Bff.HttpAggregator.Pages.BasketService;
using WebMVC.HttpAggregator.Domain.BasketService.QueryHandlers;
using WebMVC.HttpAggregator.Domain.BasketService.QueryRequests;

namespace WebMVC.Bff.HttpAggregator.Gateway.Controllers
{
    [ApiController]
    [Route("api/mvc-bff/baskets")]
    [Authorize]
    public class BasketController : BasketPage
    {
        private readonly IMediator m;
        /*private readonly IQueryHandler<PictureQuery, Resource> q;*/

        public BasketController(IMediator m/*, IQueryHandler<PictureQuery, Resource> q*/)
        {
            this.m = m;
            /*this.q = q;*/
        }

        [Route("{basketId}")]
        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<BasketView>>> GetBasket([FromRoute] GetUserBasketByIdQuery query) // + userId
        {
            /*var result = await m.Send(new GetUserBasketByIdQueryHandler(q));
            if (result is null)
            {
                return NotFound();
            }*/

            return Ok(new BasketView());
        }

        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<BasketView>>> GetBaskets()// + userId
        {
            var result = await m.Send(new GetUserBasketsQueryHandler());
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPatch] // https://stackoverflow.com/questions/58543583/how-to-bypass-antiforgery-token-validation-on-form-post-in-integration-tests
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateBasket([FromBody] UpdateBasketCommand command)
        {
            throw new NotImplementedException();
        }

        [HttpOptions]
        public ActionResult GetBasketOptions()
        {
            Response.Headers.Add("Allowed-Methods", "GET, OPTIONS, PATCH, HEAD");
            return Ok();
        }
    }
}