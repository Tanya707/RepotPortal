using System.Net;
using API.Business.Models;
using API.Business.Models.Requests;
using RestSharp;

namespace API.Business.Steps.RestSharpSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) PatchLaunchesUpdateResponse<T>(string nameOfProject, int launchNumber, PatchLaunchesUpdateRequest body)
        {
            var getEndpoint = string.Format(Endpoints.PatchLaunchesUpdate, nameOfProject, launchNumber);
            _request.Resource = getEndpoint;
            _request.AddJsonBody(body);
            var response = _client.Execute<T>(_request, Method.Put);
            return (response.Data, response.StatusCode);
        }

        public (T, HttpStatusCode) PatchLaunchesUpdateResponse<T>(string nameOfProject, int launchNumber)
        {
            var getEndpoint = string.Format(Endpoints.PatchLaunchesUpdate, nameOfProject, launchNumber);
            _request.Resource = getEndpoint;
            var response = _client.Execute<T>(_request, Method.Put);
            return (response.Data, response.StatusCode);
        }
    }
}
