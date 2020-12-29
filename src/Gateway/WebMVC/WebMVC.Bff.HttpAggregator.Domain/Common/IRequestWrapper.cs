using MediatR;

namespace WebMVC.Bff.HttpAggregator.Domain.Common
{
    public interface IRequestWrapper<T> : IRequest<Response<T>> { }
}