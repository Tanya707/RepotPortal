using System.Net;
using System.Net.Http.Json;
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
            
            var response = _client.GetAsync(getEndpoint);

            var responseData = response.Result.Content.ReadAsStringAsync().Result;

            return (JsonConvert.DeserializeObject<T>(responseData), response.Result.StatusCode);
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
