using System;
using System.Threading.Tasks;

using Layer.Api.Contexts;
using Layer.Api.Contracts;

namespace Layer.Api
{
    public class MessagesLayerApi : BaseLayerApi, IMessagesApi
    {
        public MessagesLayerApi(LayerConfiguration config)
            : base(config)
        {
        }

        public Task SendMessageAsync(string conversationId)
        {
            var url = $"{ApiUrl}/apps/{Config.ApplicationId}/conversations/{conversationId}/messages";
            throw new NotImplementedException();
        }

        public Task UploadRichContentAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetMessagesAsync(MessagePagingContext context)
        {
            var url = string.IsNullOrEmpty(context.UserId)
                          ? $"{ApiUrl}/apps/{Config.ApplicationId}/users/{context.UserId}/conversations/{context.ConversationId}/messages"
                          : $"{ApiUrl}/apps/{Config.ApplicationId}/conversations/{context.ConversationId}/messages";

            throw new NotImplementedException();
        }

        public Task GetMessageAsync(MessageContext context)
        {
            var url = string.IsNullOrEmpty(context.UserId)
                          ? $"{ApiUrl}/apps/{Config.ApplicationId}/conversations/{context.ConversationId}/messages/{context.MessageId}"
                          : $"{ApiUrl}/apps/{Config.ApplicationId}/users/{context.UserId}/messages/{context.MessageId}";

            throw new NotImplementedException();
        }

        public Task DeleteMessagesAsync(MessageContext context)
        {
            var url = $"{ApiUrl}/apps/{Config.ApplicationId}/conversations/{context.ConversationId}/messages/{context.MessageId}";
            throw new NotImplementedException();
        }

        public Task SendAnnouncementAsync()
        {
            throw new NotImplementedException();
        }

        public Task SendAdhocNotificationAsync()
        {
            throw new NotImplementedException();
        }
    }
}