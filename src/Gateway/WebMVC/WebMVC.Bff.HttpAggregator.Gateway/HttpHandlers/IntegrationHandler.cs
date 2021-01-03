using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace WebMVC.Bff.HttpAggregator.Gateway.HttpHandlers
{
    public class IntegrationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var inToken = request.Headers.Authorization?.Parameter;
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "await");
            throw new NotImplementedException();
            /*return base.SendAsync(request, cancellationToken);*/
        }

        public async Task<string> GetAccessToken(string inToken)
        {
            throw new NotImplementedException();
        }
    }
}