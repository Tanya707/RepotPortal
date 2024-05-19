using System.Net;
using API.Business.Models;
using API.Business.Models.Requests;

namespace API.Business.Steps.RestSharpSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) PatchLaunchesUpdateResponse<T>(ApiRequest request)
        {
            var getEndpoint = string.Format(Endpoints.PatchLaunchesUpdate, request.NameOfProject, request.LaunchNumber);
            return _apiSteps.Put<T>(getEndpoint, request.BodyOfRequest);
        }

        public (T, HttpStatusCode) PatchLaunchesUpdateResponseBadRequest<T>(ApiRequest request)
        {
            var getEndpoint = string.Format(Endpoints.PatchLaunchesUpdate, request.NameOfProject, request.LaunchNumber);
            return _apiSteps.Put<T>(getEndpoint);
        }
    }
}
