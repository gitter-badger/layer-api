namespace Layer.Api.Contexts
{
    public class UserContext
    {
        public UserContext(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }
    }
}