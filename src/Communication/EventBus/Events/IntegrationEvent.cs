using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace EventBus.Events
{
    public class IntegrationEvent
    {
        [JsonProperty]
        public Guid Id { get; private set; }

        [JsonProperty]
        public DateTime CreationDate { get; private set; }
    }
}