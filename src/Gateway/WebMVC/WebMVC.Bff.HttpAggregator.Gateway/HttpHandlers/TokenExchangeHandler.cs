using System.Net.Http;
using IdentityModel.AspNetCore.AccessTokenManagement;

namespace WebMVC.Bff.HttpAggregator.Gateway.HttpHandlers
{
    public class TokenExchangeHandler : DelegatingHandler
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IClientAccessTokenCache _AccessTokenCache;
        public TokenExchangeHandler()
        {
                    
        }
    }
}