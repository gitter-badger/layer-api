using System.Threading.Tasks;

using Layer.Api.Contexts;

namespace Layer.Api.Contracts
{
    public interface IMessagesApi
    {
        Task SendMessageAsync(string conversationId);

        Task UploadRichContentAsync();

        Task GetMessagesAsync(MessagePagingContext context);

        Task GetMessageAsync(MessageContext context);

        Task DeleteMessagesAsync(MessageContext context);

        Task SendAnnouncementAsync();

        Task SendAdhocNotificationAsync();
    }
}