using System.Net;
using API.Business.Models;
using API.Business.Models.Requests;
using RestSharp;

namespace API.Business.Steps.RestSharpSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) PostLaunchesResponse<T>(string nameOfProject, PostLaunchesRequest body)
        {
            var getEndpoint = string.Format(Endpoints.Launches, nameOfProject);
            _request.Resource = getEndpoint;
            _request.AddJsonBody(body);
            var response = _client.ExecutePost<T>(_request);
            return (response.Data, response.StatusCode);
        }

        public (T, HttpStatusCode) PostLaunchesResponse<T>(string nameOfProject)
        {
            var getEndpoint = string.Format(Endpoints.Launches, nameOfProject);
            _request.Resource = getEndpoint;
            var response = _client.ExecutePost<T>(_request);
            return (response.Data, response.StatusCode);
        }
    }
}
