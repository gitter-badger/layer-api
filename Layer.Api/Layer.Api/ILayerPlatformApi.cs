using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Layer.Api
{
    public interface ILayerPlatformApi
    {
        Task<LayerListResource<LayerConversation<T>>> GetConversationsAsync<T>(string userId, CancellationToken cancellationToken, int pageSize = 100, string conversationId = null)
            where T : ILayerConversationMetadata;

        Task<IEnumerable<LayerConversation<T>>> GetConversationEnumerableAsync<T>(string userId, CancellationToken cancellationToken, int pageSize = 100, string conversationId = null)
            where T : ILayerConversationMetadata;
    }
}