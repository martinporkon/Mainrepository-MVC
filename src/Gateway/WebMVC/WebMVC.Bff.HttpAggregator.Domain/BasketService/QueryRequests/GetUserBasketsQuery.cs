using System.Collections.Generic;
using MediatR;
using WebMVC.Bff.HttpAggregator.Core.Errors;
using WebMVC.Bff.HttpAggregator.Domain.CatalogService.CommandHandlers;

namespace WebMVC.HttpAggregator.Domain.BasketService.QueryRequests
{
    public class GetUserBasketsQuery : IRequest<Either<Error, IEnumerable<BasketDto>>>, IRequest<IEnumerable<BasketDto>> // TODO siin
    {

        //public GetUserBasketsQuery(string id)
        //{
        //    BasketId = id;
        //}
    }
}