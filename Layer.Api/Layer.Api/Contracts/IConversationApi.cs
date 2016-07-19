using System;
using System.Threading;
using System.Threading.Tasks;

using Layer.Api.Contexts;
using Layer.Api.Models;

namespace Layer.Api.Contracts
{
    public interface IConversationApi
    {
        Task<LayerListResource<LayerConversation<T>>> GetConversationsAsync<T>(UserPagingContext context, CancellationToken cancellationToken);

        Task<LayerConversation<T>>  GetConversationAsync<T>(Guid conversationId, CancellationToken cancellationToken, string userId = null);

        Task<LayerConversation<T>> CreateConversationAsync<T>(CancellationToken cancellationToken);

        Task DeleteConversationAsync(Guid conversationId, CancellationToken cancellationToken);
    }
}