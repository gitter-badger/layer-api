using Layer.Api.Contracts;

namespace Layer.Api.Models
{
    public class BaseMetadata : ILayerConversationMetadata
    {
        public string Title { get; set; }
    }
}