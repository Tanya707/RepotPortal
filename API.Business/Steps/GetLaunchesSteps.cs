using API.Business.Models;
using API.Business.Models.Enums;
using API.Business.Models.Responses;
using API.Business.Models.Responses.Items;
using RestSharp;
using System.Net;

namespace API.Business.Steps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) GetLaunchesResponse<T>(string nameOfProject)
        {
            var getEndpoint = string.Format(Endpoints.Launches, nameOfProject);
            _request.Resource = getEndpoint;
            var response = _client.ExecuteGet<T>(_request);
            return (response.Data, response.StatusCode);
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
