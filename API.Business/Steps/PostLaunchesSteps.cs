using System.Net;
using API.Business.Models;
using API.Business.Models.Requests;

namespace API.Business.Steps.RestSharpSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) PostLaunchesResponse<T>(ApiRequest request)
        {
            var getEndpoint = string.Format(Endpoints.Launches, request.NameOfProject);
            return _apiSteps.Post<T>(getEndpoint, request.BodyOfRequest);
        }

        public (T, HttpStatusCode) PostLaunchesResponseBadRequest<T>(ApiRequest request)
        {
            var getEndpoint = string.Format(Endpoints.Launches, request.NameOfProject);
            return _apiSteps.Post<T>(getEndpoint);
        }
    }
}
