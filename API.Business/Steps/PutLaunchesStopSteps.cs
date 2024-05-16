using System.Net;
using API.Business.Models;
using API.Business.Models.Requests;

namespace API.Business.Steps.RestSharpSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) PutLaunchesStopResponse<T>(string nameOfProject, int launchNumber, PutLaunchesStopRequest body)
        {
            var getEndpoint = string.Format(Endpoints.PutLaunchesStop, nameOfProject, launchNumber);
            return _apiSteps.Put<T>(getEndpoint,body);
        }

        public (T, HttpStatusCode) PutLaunchesStopResponse<T>(string nameOfProject, int launchNumber)
        {
            var getEndpoint = string.Format(Endpoints.PutLaunchesStop, nameOfProject, launchNumber);
            return _apiSteps.Put<T>(getEndpoint);
        }
    }
}
