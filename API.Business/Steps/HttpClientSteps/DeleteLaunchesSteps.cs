using System.Net;
using API.Business.Models;
using Newtonsoft.Json;

namespace API.Business.Steps.HttpClientSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) DeleteLaunchesResponse<T>(string nameOfProject, int launchNumber)
        {
            var getEndpoint = string.Format(Endpoints.DeleteLaunchById, nameOfProject, launchNumber);

            var response = _client.DeleteAsync(getEndpoint);

            var responseData = response.Result.Content.ReadAsStringAsync().Result;

            return (JsonConvert.DeserializeObject<T>(responseData), response.Result.StatusCode);
        }
    }
}
