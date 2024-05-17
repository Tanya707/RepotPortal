using System.Net;
using API.Business.Models;
using API.Business.Models.Requests;

namespace API.Business.Steps.RestSharpSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) PutLaunchesStopResponse<T>(ApiRequest request)
        {
            var getEndpoint = string.Format(Endpoints.PutLaunchesStop, request.NameOfProject, request.LaunchNumber);
            return _apiSteps.Put<T>(getEndpoint, request.BodyOfRequest);
        }

        public (T, HttpStatusCode) PutLaunchesStopResponseBadRequest<T>(ApiRequest request)
        {
            var getEndpoint = string.Format(Endpoints.PutLaunchesStop, request.NameOfProject, request.LaunchNumber);
            return _apiSteps.Put<T>(getEndpoint);
        }
    }
}
