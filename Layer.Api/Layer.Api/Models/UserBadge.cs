using Newtonsoft.Json;

namespace Layer.Api.Models
{
    public class UserBadge
    {
        [JsonProperty(PropertyName = "external_unread_count")]
        public long ExternalUnreadCount { get; set; }

        [JsonProperty("unread_conversation_count")]
        public long UnreadConversationCount { get; set; }

        [JsonProperty(PropertyName = "unread_message_count")]
        public long UnreadMessageCount { get; set; }
    }
}