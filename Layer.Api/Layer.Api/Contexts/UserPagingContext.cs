using System;

namespace Layer.Api.Contexts
{
    public class UserPagingContext : PagingContext
    {
        public UserPagingContext(string userId)
        {
            UserId = userId;
        }
        public string UserId { get; set; }
    }
}