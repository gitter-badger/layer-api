using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Layer.Api.Contexts;
using Layer.Api.Contracts;
using Layer.Api.Models;

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

        public async Task<LayerListResource<LayerConversation<T>>> GetConversationsAsync<T>(UserPagingContext context, CancellationToken cancellationToken) where T : ILayerConversationMetadata
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var url = $"https://api.layer.com/apps/{_appId}/users/{context.UserId}/conversations?page_size={context.PageSize}";

            if (!string.IsNullOrEmpty(context.ConversationId))
            {
                url += $"&from_id={context.ConversationId}";
            }

            return await GetListResource<LayerConversation<T>>(url, cancellationToken);
        }

        public async Task<IEnumerable<LayerConversation<T>>> GetConversationEnumerableAsync<T>(UserPagingContext context, CancellationToken cancellationToken) where T : ILayerConversationMetadata
        {
            var listResource = await GetConversationsAsync<T>(context, cancellationToken);
            return listResource.Data;
        }

        public Task<LayerConversation<T>> GetConversationAsync<T>(UserContext context, CancellationToken cancellationToken) where T : ILayerConversationMetadata
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LayerConversation<T>>> GetConversationsAsync<T>(PagingContext context, CancellationToken cancellationToken) where T : ILayerConversationMetadata
        {
            throw new NotImplementedException();
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