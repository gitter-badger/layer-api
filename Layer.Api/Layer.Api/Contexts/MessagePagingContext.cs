namespace Layer.Api.Contexts
{
    public class MessagePagingContext : PagingContext
    {
        public MessagePagingContext(string conversationId)
        {
            ConversationId = conversationId;
        }

        public string ConversationId { get; set; }

        public string UserId { get; set; }
    }
}