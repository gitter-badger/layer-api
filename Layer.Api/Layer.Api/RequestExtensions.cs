using System.Net.Http;
using System.Net.Http.Headers;

namespace Layer.Api
{
    public static class RequestExtensions
    {
        public static HttpRequestMessage SetBearerToken(this HttpRequestMessage request, string token)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return request;
        }
    }
}