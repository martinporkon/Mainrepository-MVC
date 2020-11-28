using MediatR;

namespace WebMVC.Bff.HttpAggregator.Domain.Common
{
    public interface IHandlerWrapper<in T1, T2> : IRequestHandler<T1, Response<T2>> where T1 : IRequestWrapper<T2> { }
}