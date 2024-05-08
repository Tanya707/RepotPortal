using API.Business.Models;
using API.Business.Models.Requests;
using RestSharp;
using System.Net;

namespace API.Business.Steps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) PutLaunchesStopResponse<T>(string nameOfProject, int launchNumber, PutLaunchesStopRequest body)
        {
            var getEndpoint = string.Format(Endpoints.PutLaunchesStop, nameOfProject, launchNumber);
            _request.Resource = getEndpoint;
            _request.AddJsonBody(body);
            var response = _client.ExecutePut<T>(_request);
            return (response.Data, response.StatusCode);
        }

        public (T, HttpStatusCode) PutLaunchesStopResponse<T>(string nameOfProject, int launchNumber)
        {
            var getEndpoint = string.Format(Endpoints.PutLaunchesStop, nameOfProject, launchNumber);
            _request.Resource = getEndpoint;
            var response = _client.ExecutePut<T>(_request);
            return (response.Data, response.StatusCode);
        }
    }
}
