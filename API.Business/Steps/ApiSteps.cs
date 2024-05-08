using API.Business.Controllers;
using Core.Helpers;
using Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace API.Business.Steps
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

        public T? DeserializeResponse<T>(RestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
