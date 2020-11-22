using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace SooduskorvWebMVC.PostConfigurationOptions
{
    public class OpenIdConnectOptionsPostConfigurationOptions : IPostConfigureOptions<OpenIdConnectOptions>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OpenIdConnectOptionsPostConfigurationOptions(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ??
                                 throw new ArgumentNullException(nameof(httpClientFactory));
        }
        public void PostConfigure(string name, OpenIdConnectOptions options)
        {
            options.Events = new OpenIdConnectEvents
            {
                OnTicketReceived = async ticketReceivedContext =>
                {
                    var subject = ticketReceivedContext.Principal.Claims
                        .FirstOrDefault(c => c.Type == "sub")?.Value;

                    var apiClient = _httpClientFactory.CreateClient("APIClient");

                    var request = new HttpRequestMessage(
                        HttpMethod.Get,
                        $"api/applicationuserprofiles/{subject}");// TODO
                    request.SetBearerToken(ticketReceivedContext.Properties.GetTokenValue(OpenIdConnectParameterNames.AccessToken));

                    var response = await apiClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                        .ConfigureAwait(false);

                    response.EnsureSuccessStatusCode();

                    var result = new ApplicationUserProfileDto();
                    await using var responseStream = await response.Content.ReadAsStreamAsync();
                    result = await JsonSerializer.DeserializeAsync<ApplicationUserProfileDto>(responseStream);

                    var newClaimsIdentity = new ClaimsIdentity();
                    newClaimsIdentity.AddClaim(new Claim("subscriptionlevel", result.SubscriptionLevel));

                    ticketReceivedContext.Principal.AddIdentity(newClaimsIdentity);
                }
            };
        }
    }

    public class ApplicationUserProfileDto
    {//
        public string SubscriptionLevel { get; set; }
    }
}