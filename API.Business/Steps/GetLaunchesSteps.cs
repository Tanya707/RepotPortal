using System.Net;
using API.Business.Models;
using API.Business.Models.Enums;
using API.Business.Models.Responses;
using API.Business.Models.Responses.Items;

namespace API.Business.Steps.RestSharpSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) GetLaunchesResponse<T>(ApiRequest request)
        {
            var getEndpoint = string.Format(Endpoints.Launches, request.NameOfProject);
            return _apiSteps.Get<T>(getEndpoint);
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
