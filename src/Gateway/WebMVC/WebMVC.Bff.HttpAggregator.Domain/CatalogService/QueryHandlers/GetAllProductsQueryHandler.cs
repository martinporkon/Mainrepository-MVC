using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Net.Client;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Bff.HttpAggregator.Domain.CatalogService.QueryRequest;
using WebMVC.Bff.HttpAggregator.Domain.DTO;

namespace WebMVC.HttpAggregator.Domain.Catalog.QueriesHandlers
{
    public class GetAllProductsQueryHandler<T> : IRequestHandler<T, ActionResult<IEnumerable<ProductDto>>> where T : GetAllProductsQuery, IRequest<ActionResult<IEnumerable<ProductDto>>>
    {
        /*private readonly IQueryHandler<PictureQuery, Resource> _resourceQueryHandler;#1#*/

        /*// TODO kas sobiks ka ActionResult??*/
        public GetAllProductsQueryHandler()
        {

        }

        public Task<ActionResult<IEnumerable<ProductDto>>> Handle(T request, CancellationToken cancellationToken)
        {
            var client = new HttpClient(new HttpClientHandler());
            var opt = new GrpcChannelOptions { HttpClient = client };
            var url = "";// TODO peaks toimuma infras.
            var channel = GrpcChannel.ForAddress(url, opt);
            throw new NotImplementedException();
        }
    }
}