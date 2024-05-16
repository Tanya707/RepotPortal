using Core.Helpers;
using Core.Models;
using RestSharp;
using System.Net;

namespace Core.HttpClient
{
    public class RestClient : IHttpClient
    {
        private readonly RestSharp.RestClient _restClient;
        private RestRequest _restRequest;


        public RestClient(string url)
        {
            _restClient = new RestSharp.RestClient(url);
        }

        public RestClient(TokenRequestModel tokenRequest)
        {
            var token = TokenService.GenerateToken(tokenRequest);
            _restClient = new RestSharp.RestClient(tokenRequest.BaseUrl);
            _restClient.AddDefaultHeader("Authorization", $"Bearer {token}");
            _restRequest = new RestRequest(); ;
        }

        public (T, HttpStatusCode) Get<T>(string getEndpoint)
        {
            _restRequest.Resource = getEndpoint;
            var response = _restClient.ExecuteGet<T>(_restRequest);
            return (response.Data, response.StatusCode);
        }

        public (T, HttpStatusCode) Delete<T>(string getEndpoint)
        {
            _restRequest.Resource = getEndpoint;
            var response = _restClient.Execute<T>(_restRequest, Method.Delete);
            return (response.Data, response.StatusCode);
        }

        public (T, HttpStatusCode) Put<T>(string getEndpoint, object body)
        {
            _restRequest.Resource = getEndpoint;
            _restRequest.AddJsonBody(body);
            var response = _restClient.ExecutePut<T>(_restRequest);
            return (response.Data, response.StatusCode);
        }

        public (T, HttpStatusCode) Put<T>(string getEndpoint)
        {
            _restRequest.Resource = getEndpoint;
            var response = _restClient.ExecutePut<T>(_restRequest);
            return (response.Data, response.StatusCode);
        }

        public (T, HttpStatusCode) Post<T>(string getEndpoint, object body)
        {
            _restRequest.Resource = getEndpoint;
            _restRequest.AddJsonBody(body);
            var response = _restClient.ExecutePost<T>(_restRequest);
            return (response.Data, response.StatusCode);
        }

        public (T, HttpStatusCode) Post<T>(string getEndpoint)
        {
            _restRequest.Resource = getEndpoint;
            var response = _restClient.ExecutePost<T>(_restRequest);
            return (response.Data, response.StatusCode);
        }

        public void CleanUp()
        {
            _restClient.Dispose();
        }
    }
}
