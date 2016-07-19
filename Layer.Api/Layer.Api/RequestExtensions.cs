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

        public static HttpRequestMessage SetContentType(this HttpRequestMessage request)
        {
            request.Content.Headers.ContentType = request.Method.Method == "PATCH"
                ? new MediaTypeHeaderValue("application/vnd.layer-patch+json")
                : new MediaTypeHeaderValue("application/json");

            return request;
        }
    }
}