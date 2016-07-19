using Newtonsoft.Json;

namespace Layer.Api.Models
{
    internal class UserId
    {
        [JsonProperty(PropertyName = "user_id")]
        public string Id { get; set; }
    }
}