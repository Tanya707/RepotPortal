using API.Business.Controllers;
using RestSharp;

namespace API.Business.Steps.RestSharpSteps
{
    public partial class ApiSteps
    {
        private RestClient _client;
        private RestRequest _request;

        public ApiSteps(string baseUrl, string token)
        {
            _client = new RestClient(baseUrl);
            _client.AddDefaultAuthToken(token);
            _request = new RestRequest();
        }

        public void CleanUp()
        {
            _client.Dispose();
        }
    }
}
