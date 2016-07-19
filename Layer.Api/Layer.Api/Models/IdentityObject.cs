using System.Collections.Generic;

using Newtonsoft.Json;

namespace Layer.Api.Models
{
    public class IdentityObject
    {
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "email_address")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "public_key")]
        public string PublicKey { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public IDictionary<string, string> Metadata { get; set; }
    }
}