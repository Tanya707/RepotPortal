﻿using System.Net;
using API.Business.Models;
using RestSharp;

namespace API.Business.Steps.RestSharpSteps
{
    public partial class ApiSteps
    {
        public (T, HttpStatusCode) DeleteLaunchesResponse<T>(string nameOfProject, int launchNumber)
        {
            var getEndpoint = string.Format(Endpoints.DeleteLaunchById, nameOfProject, launchNumber);
            _request.Resource = getEndpoint;
            var response = _client.Execute<T>(_request, Method.Delete);
            return (response.Data, response.StatusCode);
        }
    }
}
