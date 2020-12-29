using System;
using Newtonsoft.Json;
using Sooduskorv_MVC.Shared.Token;

namespace EventBus.Events
{
    public class IntegrationEvent
    {
        [JsonProperty]
        public SecurityTokenContext SecurityTokenContext { get; set; } = new SecurityTokenContext();
        [JsonProperty]
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        [JsonProperty]
        public DateTime CreationDate { get; private set; }
    }
}