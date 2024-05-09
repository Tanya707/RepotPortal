using System.Net;
using API.Business.Models;
using API.Business.Models.Enums;
using API.Business.Models.Responses;
using API.Business.Models.Responses.Items;
using Newtonsoft.Json;

namespace API.Business.Steps.HttpClientSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) GetLaunchesResponse<T>(string nameOfProject)
        {

            var getEndpoint = string.Format(Endpoints.Launches, nameOfProject);

            _request.RequestUri = new Uri(_client.BaseAddress,getEndpoint);
            _request.Method = HttpMethod.Get;

            var response = _client.SendAsync(_request).GetAwaiter().GetResult();

            var responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return (JsonConvert.DeserializeObject<T>(responseData), response.StatusCode);
        }

        public List<Execution> InProgressExecutions(GetLaunchesResponse dataGet)
        {
            List<Execution> inProgressExecutions = new List<Execution>();

            foreach (var execution in dataGet.Content)
            {
                if (execution.Status == Status.IN_PROGRESS.ToString())
                {
                    inProgressExecutions.Add(execution);
                }
            } 
            return inProgressExecutions;
        }

    }
}
