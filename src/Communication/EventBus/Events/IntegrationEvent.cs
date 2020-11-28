using System;
using Newtonsoft.Json;

namespace EventBus.Events
{
    public class IntegrationEvent
    {
        [JsonProperty] public string Id { get; private set; } = Guid.NewGuid().ToString();

        [JsonProperty] public DateTime CreationDate { get; private set; }
    }
}