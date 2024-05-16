using System.Net;
using API.Business.Models;
using API.Business.Models.Requests;

namespace API.Business.Steps.RestSharpSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) PostLaunchesResponse<T>(string nameOfProject, PostLaunchesRequest body)
        {
            var getEndpoint = string.Format(Endpoints.Launches, nameOfProject);
            return _apiSteps.Post<T>(getEndpoint,body);
        }

        public (T, HttpStatusCode) PostLaunchesResponse<T>(string nameOfProject)
        {
            var getEndpoint = string.Format(Endpoints.Launches, nameOfProject);
            return _apiSteps.Post<T>(getEndpoint);
        }
    }
}
