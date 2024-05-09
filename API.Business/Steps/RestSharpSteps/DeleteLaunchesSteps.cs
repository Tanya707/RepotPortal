using System.Net;
using API.Business.Models;
using API.Business.Models.Requests;
using RestSharp;

namespace API.Business.Steps.RestSharpSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) DeleteLaunchesResponse<T>(string nameOfProject, DeleteLaunchesRequest body)
        {
            var getEndpoint = string.Format(Endpoints.Launches, nameOfProject);
            _request.Resource = getEndpoint;
            _request.AddJsonBody(body);
            var response = _client.Execute<T>(_request, Method.Delete);
            return (response.Data, response.StatusCode);
        }

        public (T, HttpStatusCode) DeleteLaunchesResponse<T>(string nameOfProject)
        {
            var getEndpoint = string.Format(Endpoints.Launches, nameOfProject);
            _request.Resource = getEndpoint;
            var response = _client.Execute<T>(_request, Method.Delete);
            return (response.Data, response.StatusCode);
        }
    }
}
