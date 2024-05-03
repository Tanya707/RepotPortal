using RestSharp;

namespace API.Business.Controllers
{
    public static class RestTokenClient
    {
        public static IRestClient AddDefaultAuthToken(this IRestClient client, string token)
        {
            return client.AddDefaultHeader("Authorization", $"Bearer {token}");
        }
    }
}
