using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SooduskorvWebMVC.Models;
using WebMVC.Bff.HttpAggregator.Gateway.Controllers;
using WebMVC.Bff.HttpAggregator.Infra.CatalogService.QueryRequest;

namespace WebMVC.HttpAggregator.Gateway.Controllers
{
    [ApiController]
    [Route("api/mvc-bff/products")]
    [AllowAnonymous]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("/all")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts([FromQuery] Filters filters)
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery()) as IEnumerable<ProductDto>);
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
        public async Task<ActionResult<ProductDto>> GetProduct(string productId)
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery()));
        }


        [Route("/basket/{productId}")]
        [HttpPost]
        public async Task<ActionResult> AddToBasket(string productId)
        {

            if (productId is null)
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