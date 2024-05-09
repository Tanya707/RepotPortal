using System.Net;
using System.Text;
using API.Business.Models;
using API.Business.Models.Requests;
using Newtonsoft.Json;

namespace API.Business.Steps.HttpClientSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) PutLaunchesStopResponse<T>(string nameOfProject, int launchNumber, PutLaunchesStopRequest body)
        {
            var getEndpoint = string.Format(Endpoints.PutLaunchesStop, nameOfProject, launchNumber);
            _request.RequestUri = new Uri(_client.BaseAddress,getEndpoint);
            _request.Method = HttpMethod.Put;

            var jsonBody = JsonConvert.SerializeObject(body);
            _request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var response = _client.SendAsync(_request).GetAwaiter().GetResult();

            var responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return (JsonConvert.DeserializeObject<T>(responseData), response.StatusCode);
        }

        public (T, HttpStatusCode) PutLaunchesStopResponse<T>(string nameOfProject, int launchNumber)
        {
            var getEndpoint = string.Format(Endpoints.PutLaunchesStop, nameOfProject, launchNumber);
            _request.RequestUri = new Uri(_client.BaseAddress,getEndpoint);
            _request.Method = HttpMethod.Put;

            var response = _client.SendAsync(_request).GetAwaiter().GetResult();

            var responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return (JsonConvert.DeserializeObject<T>(responseData), response.StatusCode);
        }
    }
}
