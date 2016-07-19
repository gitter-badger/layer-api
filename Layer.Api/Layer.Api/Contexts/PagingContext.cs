namespace Layer.Api.Contexts
{
    public class PagingContext
    {
        public int PageSize { get; set; } = 100;

        public string FromId { get; set; }
    }
}