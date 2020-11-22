using MediatR;

namespace WebMVC.HttpAggregator.Infra.Common
{
    public interface IRequestWrapper<T> : IRequest<Response<T>> { }
}