using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Layer.Api.Contexts;
using Layer.Api.Models;

namespace Layer.Api.Contracts
{
    public interface ILayerPlatformApi
    {
        Task<LayerListResource<LayerConversation<T>>> GetConversationsAsync<T>(UserPagingContext context, CancellationToken cancellationToken)
            where T : ILayerConversationMetadata;

        Task<IEnumerable<LayerConversation<T>>> GetConversationEnumerableAsync<T>(UserPagingContext context, CancellationToken cancellationToken)
            where T : ILayerConversationMetadata;

        Task<LayerConversation<T>> GetConversationAsync<T>(UserContext context, CancellationToken cancellationToken)
            where T : ILayerConversationMetadata;

        Task<IEnumerable<LayerConversation<T>>> GetConversationsAsync<T>(PagingContext context, CancellationToken cancellationToken)
            where T : ILayerConversationMetadata;
    }
}