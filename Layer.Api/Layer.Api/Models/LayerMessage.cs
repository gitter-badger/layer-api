using System;

namespace Layer.Api.Models
{
    public class LayerMessage
    {
        public string Id { get; set; }

        public Guid Uuid { get; set; }

        public long Position { get; set; }

        public DateTimeOffset SentAt { get; set; }

        public DateTimeOffset ReceivedAt { get; set; }
    }
}