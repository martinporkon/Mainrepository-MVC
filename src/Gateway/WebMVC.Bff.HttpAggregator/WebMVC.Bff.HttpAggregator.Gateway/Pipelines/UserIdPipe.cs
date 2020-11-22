using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace WebMVC.HttpAggregator.Gateway.Infrastructure
{
    public class UserIdPipe<T1, T2> : IPipelineBehavior<T1, T2>
    {
        private readonly HttpContext _httpContext;

        public UserIdPipe(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<T2> Handle(T1 request, CancellationToken cancellationToken, RequestHandlerDelegate<T2> next)
        {
            var userClaims = _httpContext.User.Claims
                .FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))// TODO change for later.
                ?.Value;

            // TODO add token
            // pre
            var result = await next();
            // post
            return result;
        }
    }
}