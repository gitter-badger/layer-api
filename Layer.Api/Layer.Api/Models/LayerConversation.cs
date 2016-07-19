using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Layer.Api.Models
{
    public class LayerConversation<TMetadata>
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonIgnore]
        public Guid? Uuid
        {
            get
            {
                Guid result;
                if (!string.IsNullOrEmpty(Id) && Guid.TryParse(Id.Replace("layer:///conversations/", string.Empty), out result))
                {
                    return result;
                }
                return null;
            }
        }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("messages_url")]
        public string MessagesUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("participants")]
        public IEnumerable<string> Participants { get; set; }

        [JsonProperty("distinct")]
        public bool Distinct { get; set; }

        [JsonProperty("metadata")]
        public TMetadata Metadata { get; set; }
    }
}