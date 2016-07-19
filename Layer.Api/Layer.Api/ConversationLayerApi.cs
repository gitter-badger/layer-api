using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Layer.Api.Contexts;
using Layer.Api.Contracts;
using Layer.Api.Models;

namespace Layer.Api
{
    public class ConversationLayerApi : BaseLayerApi, IConversationApi
    {
        public ConversationLayerApi(LayerConfiguration config)
            : base(config)
        {
        }

        public Task<LayerListResource<LayerConversation<T>>> GetConversationsAsync<T>(UserPagingContext context, CancellationToken cancellationToken)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var url = $"{ApiUrl}/apps/{Config.ApplicationId}/users/{context.UserId}/conversations?page_size={context.PageSize}";

            if (!string.IsNullOrEmpty(context.FromId))
            {
                url += $"&from_id={context.FromId}";
            }

            return GetListResource<LayerConversation<T>>(url, cancellationToken);
        }

        public Task<LayerConversation<T>> GetConversationAsync<T>(Guid conversationId, CancellationToken cancellationToken, string userId = null)
        {
            var url = string.IsNullOrEmpty(userId) 
                ? $"{ApiUrl}/apps/{Config.ApplicationId}/conversations/{conversationId}" //system perspective
                : $"{ApiUrl}/apps/{Config.ApplicationId}/users/{userId}/conversations/{conversationId}"; //user perspective

            return SendAsync<LayerConversation<T>>(url, HttpMethod.Get, cancellationToken);
        }

        public Task<LayerConversation<T>> CreateConversationAsync<T>(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteConversationAsync(Guid conversationId, CancellationToken cancellationToken)
        {
            var url = $"{ApiUrl}/apps/{Config.ApplicationId}/conversations/{conversationId}";
            return SendAsync(url, HttpMethod.Delete, cancellationToken);
        }
    }
}