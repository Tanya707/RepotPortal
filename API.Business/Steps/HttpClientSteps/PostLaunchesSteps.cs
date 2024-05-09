using System.Net;
using System.Text;
using API.Business.Models;
using API.Business.Models.Requests;
using Newtonsoft.Json;

namespace API.Business.Steps.HttpClientSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) PostLaunchesResponse<T>(string nameOfProject, PostLaunchesRequest body)
        {

            var getEndpoint = string.Format(Endpoints.Launches, nameOfProject);
            using (var request = new HttpRequestMessage(HttpMethod.Post, new Uri(_client.BaseAddress, getEndpoint)))
            {

                var jsonBody = JsonConvert.SerializeObject(body);
                _request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = _client.SendAsync(_request).GetAwaiter().GetResult();

                var responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return (JsonConvert.DeserializeObject<T>(responseData), response.StatusCode);
            }
        }

        public (T, HttpStatusCode) PostLaunchesResponse<T>(string nameOfProject)
        {
            var getEndpoint = string.Format(Endpoints.Launches, nameOfProject);
            _request.RequestUri = new Uri(_client.BaseAddress,getEndpoint);
            _request.Method = HttpMethod.Post;

            var response = _client.SendAsync(_request).GetAwaiter().GetResult();

            var responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return (JsonConvert.DeserializeObject<T>(responseData), response.StatusCode);
        }
    }
}
