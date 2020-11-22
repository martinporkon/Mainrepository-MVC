using System.Collections.Generic;
using MediatR;
using WebMVC.Bff.HttpAggregator.Core.Errors;
using WebMVC.Bff.HttpAggregator.Domain.DTO;

namespace WebMVC.HttpAggregator.Domain.BasketService.QueryHandlers
{
    public class GetUserBasketsQuery : IRequest<Either<Error, IEnumerable<BasketDto>>>, IRequest<IEnumerable<BasketDto>> // TODO siin
    {

        //public GetUserBasketsQuery(string id)
        //{
        //    BasketId = id;
        //}
    }
}