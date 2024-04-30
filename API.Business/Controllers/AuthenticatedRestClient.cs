using Core.Helpers;
using Core.Models;
using RestSharp;

namespace API.Business.Steps
{
    public class AuthenticatedRestClient
    {
        private readonly RestClient _client;
        private readonly Settings _settings = SettingHelper.LoadFromAppSettings();

        private readonly string _token;

        public AuthenticatedRestClient(string baseUrl, string username, string password)
        {
            _client = new RestClient(baseUrl);
            _token = TokenService.GenerateToken(baseUrl, username, password);
        }

        public RestResponse Execute(RestRequest request)
        {
            request.AddHeader("Authorization", $"Bearer {_token}");
            var response = _client.Execute(request);
            return response;
        }
    }
}
