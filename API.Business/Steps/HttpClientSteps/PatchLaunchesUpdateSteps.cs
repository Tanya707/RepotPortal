using System.Net;
using System.Text;
using API.Business.Models;
using API.Business.Models.Requests;
using Newtonsoft.Json;

namespace API.Business.Steps.HttpClientSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) PatchLaunchesUpdateResponse<T>(string nameOfProject, int launchNumber, PatchLaunchesUpdateRequest body)
        {
            var getEndpoint = string.Format(Endpoints.PatchLaunchesUpdate, nameOfProject, launchNumber);

            using (var request = new HttpRequestMessage(HttpMethod.Put, new Uri(_client.BaseAddress, getEndpoint)))
            {
                var jsonBody = JsonConvert.SerializeObject(body);
                request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                var response = _client.SendAsync(request).GetAwaiter().GetResult();

                var responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                return (JsonConvert.DeserializeObject<T>(responseData), response.StatusCode);
            }
        }

        public (T, HttpStatusCode) PatchLaunchesUpdateResponse<T>(string nameOfProject, int launchNumber)
        {
            var getEndpoint = string.Format(Endpoints.PatchLaunchesUpdate, nameOfProject, launchNumber);
            _request.RequestUri = new Uri(_client.BaseAddress,getEndpoint);
            _request.Method = HttpMethod.Put;

            var response = _client.SendAsync(_request).GetAwaiter().GetResult();

            var responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return (JsonConvert.DeserializeObject<T>(responseData), response.StatusCode);
        }
    }
}
