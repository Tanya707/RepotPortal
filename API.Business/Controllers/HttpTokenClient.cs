using System.Net.Http.Headers;

namespace API.Business.Controllers
{
    public static class HttpTokenClient
    {
        public static HttpClient AddDefaultHttpAuthToken(this HttpClient client, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return client;
        }
    }
}
