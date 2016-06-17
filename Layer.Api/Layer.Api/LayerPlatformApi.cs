using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Layer.Api
{
    public class LayerPlatformApi : ILayerPlatformApi
    {
        private readonly string _appId;
        private readonly string _platformApiKey;
        private readonly string _version;

        private readonly HttpClient _httpClient = new HttpClient();

        private bool _disposed;

        public LayerPlatformApi(string appId, string platformApiKey, string version = "1.0")
        {
            _appId = appId;
            _platformApiKey = platformApiKey;
            _version = version;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _httpClient.Dispose();
            }

            _disposed = true;
            GC.SuppressFinalize(this);
        }

        public async Task<LayerListResource<LayerConversation<T>>> GetConversationsAsync<T>(string userId, CancellationToken cancellationToken, int pageSize = 100, string conversationId = null)
            where T : ILayerConversationMetadata
        {
            var url = $"https://api.layer.com/apps/{_appId}/users/{userId}/conversations?page_size={pageSize}";

            if (!string.IsNullOrEmpty(conversationId))
            {
                url += $"&from_id={conversationId}";
            }
            return await GetListResource<LayerConversation<T>>(url, cancellationToken);
        }

        public async Task<IEnumerable<LayerConversation<T>>> GetConversationEnumerableAsync<T>(string userId, CancellationToken cancellationToken, int pageSize = 100, string conversationId = null) where T : ILayerConversationMetadata
        {
            var listResource = await GetConversationsAsync<T>(userId, cancellationToken, pageSize, conversationId);
            return listResource.Data;
        }

        private async Task<LayerListResource<T>> GetListResource<T>(string url, CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.SetBearerToken(_platformApiKey);

            request.Headers.Add("Accept", $"application/vnd.layer+json; version={_version}");

            var result = await _httpClient.SendAsync(request, cancellationToken);
            var json = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode)
            {
                var totalCount = Convert.ToInt32(result.Headers.GetValues("Layer-Count").FirstOrDefault());
                var data = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
                return new LayerListResource<T> { TotalCount = totalCount, Data = data };
            }
            throw new InvalidOperationException($"Layer platform api exception: {json}");
        }
    }
}