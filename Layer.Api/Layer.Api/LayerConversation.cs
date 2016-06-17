using System;
using System.Collections.Generic;

namespace Layer.Api
{
    public class LayerConversation<TMetadata>
        where TMetadata : ILayerConversationMetadata
    {
        public string Id { get; set; }

        public Guid Uuid { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public IEnumerable<string> Participants { get; set; }

        public bool Distinct { get; set; }

        public TMetadata Metadata { get; set; }
    }
}