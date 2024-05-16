using System.Net;
using API.Business.Models;
using API.Business.Models.Requests;

namespace API.Business.Steps.RestSharpSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) PatchLaunchesUpdateResponse<T>(string nameOfProject, int launchNumber, PatchLaunchesUpdateRequest body)
        {
            var getEndpoint = string.Format(Endpoints.PatchLaunchesUpdate, nameOfProject, launchNumber);
            return _apiSteps.Put<T>(getEndpoint,body);
        }

        public (T, HttpStatusCode) PatchLaunchesUpdateResponse<T>(string nameOfProject, int launchNumber)
        {
            var getEndpoint = string.Format(Endpoints.PatchLaunchesUpdate, nameOfProject, launchNumber);
            return _apiSteps.Put<T>(getEndpoint);
        }
    }
}
