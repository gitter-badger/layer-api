namespace Layer.Api.Contexts
{
    public class MessageContext
    {
        public MessageContext(string messageId, string conversationId)
        {
            MessageId = messageId;
            ConversationId = conversationId;
        }
        public string ConversationId { get; set; }

        public string UserId { get; set; }

        public string MessageId { get; set; }
    }
}