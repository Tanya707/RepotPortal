using System.Net;
using API.Business.Models;

namespace API.Business.Steps.RestSharpSteps
{
    public partial class ApiSteps
    {

        public (T, HttpStatusCode) DeleteLaunchesResponse<T>(ApiRequest request)
        {
            var getEndpoint = string.Format(Endpoints.DeleteLaunchById, request.NameOfProject, request.LaunchNumber);
            return _apiSteps.Delete<T>(getEndpoint);
        }
    }
}
