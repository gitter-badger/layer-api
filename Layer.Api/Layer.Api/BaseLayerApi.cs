using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Layer.Api.Models;
using Newtonsoft.Json;

namespace Layer.Api
{
    public class BaseLayerApi
    {
        private const string LayerCount = "Layer-Count";
        protected const string ApiUrl = "https://api.layer.com";
        protected readonly LayerConfiguration Config;
        private readonly Lazy<HttpClient> _httpClient = new Lazy<HttpClient>();

        public BaseLayerApi(LayerConfiguration config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            if (string.IsNullOrEmpty(config.ApplicationId))
            {
                throw new ArgumentNullException(nameof(config.ApplicationId));
            }

            if (string.IsNullOrEmpty(config.PlatformApiKey))
            {
                throw new ArgumentNullException(nameof(config.PlatformApiKey));
            }

            Config = config;
        }

        protected async Task SendAsync(string url, HttpMethod httpMethod, CancellationToken cancellationToken, object body = null)
        {
            var result = await SendRequestAsync(url, httpMethod, cancellationToken, body);
            var json = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode)
            {
                return;
            }
            throw new InvalidOperationException($"Layer platform api exception: {json}");
        }

        protected async Task<T> SendAsync<T>(string url, HttpMethod httpMethod, CancellationToken cancellationToken, object body = null)
        {
            var result = await SendRequestAsync(url, httpMethod, cancellationToken, body);
            var json = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            throw new InvalidOperationException($"Layer platform api exception: {json}");
        }

        private async Task<HttpResponseMessage> SendRequestAsync(string url, HttpMethod httpMethod, CancellationToken cancellationToken, object body = null, Guid? deduplicate = null)
        {
            var request = new HttpRequestMessage(httpMethod, url);

            if (body != null)
            {
                var content = JsonConvert.SerializeObject(body);
                request.Content = new StringContent(content);
                request.SetContentType();
            }

            if (deduplicate.HasValue)
            {
                request.Headers.IfNoneMatch.Add(new EntityTagHeaderValue(deduplicate.Value.ToString()));
            }

            request.SetBearerToken(Config.PlatformApiKey);

            return await _httpClient.Value.SendAsync(request, cancellationToken);
        }

        protected async Task<LayerListResource<T>> GetListResource<T>(string url, CancellationToken cancellationToken)
        {
            var result = await SendRequestAsync(url, HttpMethod.Get, cancellationToken);
            var json = await result.Content.ReadAsStringAsync();

            if (result.IsSuccessStatusCode)
            {
                var totalCount = GetTotalCount(result);
                var data = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
                return new LayerListResource<T> { TotalCount = totalCount, Data = data };
            }
            throw new InvalidOperationException($"Layer platform api exception: {json}");
        }

        private static int GetTotalCount(HttpResponseMessage result)
        {
            return Convert.ToInt32(result.Headers.GetValues(LayerCount).FirstOrDefault());
        }
    }
}