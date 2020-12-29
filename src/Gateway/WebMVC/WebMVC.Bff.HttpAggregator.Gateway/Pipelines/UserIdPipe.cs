using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using WebMVC.Bff.HttpAggregator.Core.User;
using WebMVC.Bff.HttpAggregator.Domain.Common;

namespace WebMVC.Bff.HttpAggregator.Gateway.Infrastructure
{
    public class UserIdPipe<T1, T2> : IPipelineBehavior<T1, T2>
    {
        private readonly IHttpContextAccessor _httpContext;

        public UserIdPipe(IHttpContextAccessor httpC)
        {
            _httpContext = httpC;
        }

        public async Task<T2> Handle(T1 request, CancellationToken cancellationToken, RequestHandlerDelegate<T2> next)
        {
            if (request is BaseRequest br)
            {
                var userClaims = new CurrentUserAccessor(_httpContext);
                br.UserId = userClaims.UserId;
            }
            // get from database
            // pre
            var result = await next();
            // post
            return result;
        }
    }
}