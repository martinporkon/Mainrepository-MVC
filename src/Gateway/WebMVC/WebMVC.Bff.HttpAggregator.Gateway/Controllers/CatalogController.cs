using System.Collections.Generic;
using System.Threading.Tasks;
using Basket.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sooduskorv_MVC.Aids.HTTP;
using SooduskorvWebMVC.Models;
using WebMVC.Bff.HttpAggregator.Domain.BasketService.CommandRequests;
using WebMVC.Bff.HttpAggregator.Domain.CatalogService.QueryRequest;
using WebMVC.Bff.HttpAggregator.Infra.CatalogService.QueryRequest;

namespace WebMVC.Bff.HttpAggregator.Gateway.Controllers
{
    [ApiController]
    [Route("api/mvc-bff/products")]
    [AllowAnonymous]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediator;
        /*private readonly IUnitOfWork _unitOfWork;*/// TODO

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("/all")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts([FromQuery] Filters filters)
        {
            var result = await _mediator.Send(new GetAllProductsQuery());// TODO fix needed
            return Ok(result);
        }

        [HttpGet("{manyIds}", Name = "GetProducts")]
        public ActionResult GetProducts([FromRoute] IEnumerable<string> manyIds)
        {
            // 1,2,3,4,5
            if (manyIds is null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [Route("{productId}", Name = "GetProduct")]
        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetProduct([FromBody] GetProductByIdQuery query)
        {
            if (query is null)
            {
                return NotFound();
            }
            return Ok(await _mediator.Send(query));
        }


        [Route("/basket/{productId}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddToBasket([FromBody] CreateBasketCommand command)// + userId
        {

            if (command is null)
            {
                return BadRequest();
            }
            // add
            return CreatedAtRoute("GetProduct", new { productId = "yrt545er" }, new { });
        }

        [HttpOptions]
        public ActionResult GetProductOptions()
        {
            Response.Headers.Add("Allowed-Methods", "GET, POST, OPTIONS");
            return Ok();
        }

    }
}