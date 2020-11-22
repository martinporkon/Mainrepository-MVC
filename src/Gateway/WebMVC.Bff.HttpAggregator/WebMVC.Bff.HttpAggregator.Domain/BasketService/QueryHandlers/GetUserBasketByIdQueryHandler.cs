using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebMVC.Bff.HttpAggregator.Domain.CurrentService.CurrentServiceQuery;
using WebMVC.Bff.HttpAggregator.Domain.CurrentService.Entities;
using WebMVC.Bff.HttpAggregator.Domain.DTO;
using WebMVC.Bff.HttpAggregator.Infra.Common;
using WebMVC.HttpAggregator.Domain.BasketService.QueryRequests;

namespace WebMVC.HttpAggregator.Domain.BasketService.QueryHandlers
{
    public class GetUserBasketByIdQueryHandler : IRequestHandler<GetUserBasketByIdQuery, BasketDto>
    {
        private readonly IQueryHandler<PictureQuery, Resource> _pictureQueryHandler;

        public GetUserBasketByIdQueryHandler(IQueryHandler<PictureQuery, Resource> pictureQueryHandler)
        {
            _pictureQueryHandler = pictureQueryHandler;
        }

        public async Task<BasketDto> Handle(GetUserBasketByIdQuery request, CancellationToken cancellationToken)
        {
            // query database
            var allImages = await _pictureQueryHandler.HandleAsync(new PictureQuery()/*ids*/, cancellationToken);

            // query sent to basket
            // get basket

            // generate abstractions for querying the correct service. do so via interface?

            // merge basket and allImages

            // return result;

            throw new System.NotImplementedException();
        }
    }
}