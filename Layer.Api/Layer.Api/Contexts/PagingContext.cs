using Layer.Api.Models;

namespace Layer.Api.Contexts
{
    public class PagingContext
    {
        public int PageSize { get; set; } = 100;

        public string ConversationId { get; set; }

        public ConversationSort Type { get; set; } = ConversationSort.CreatedAt;
    }
}