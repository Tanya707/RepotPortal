using Core.Helpers;
using Core.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;


namespace Core.HttpClient
{
    public class ClientOfHttp : IHttpClient
    {

        private System.Net.Http.HttpClient _httpClient;
        private HttpRequestMessage _httpRequest;

        public ClientOfHttp(string url)
        {
            _httpClient = new System.Net.Http.HttpClient();
            _httpClient.BaseAddress = new Uri(url);
            _httpRequest = new HttpRequestMessage();
        }


        public ClientOfHttp(TokenRequestModel tokenRequest)
        {
            var token = TokenServiceHttpClient.GenerateToken(tokenRequest);
            _httpClient = new System.Net.Http.HttpClient();
            _httpClient.BaseAddress = new Uri(tokenRequest.BaseUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            _httpRequest = new HttpRequestMessage();
        }


        public void CleanUp()
        {
            _httpClient.CancelPendingRequests();
            _httpClient.Dispose();
        }


        public (T, HttpStatusCode) Delete<T>(string getEndpoint)
        {
            var response = _httpClient.DeleteAsync(getEndpoint);

            var responseData = response.Result.Content.ReadAsStringAsync().Result;

            return (JsonConvert.DeserializeObject<T>(responseData), response.Result.StatusCode);
        }

        public (T, HttpStatusCode) Get<T>(string getEndpoint)
        {
            var response = _httpClient.GetAsync(getEndpoint).GetAwaiter().GetResult();

            var responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return (JsonConvert.DeserializeObject<T>(responseData), response.StatusCode);
        }

        public (T, HttpStatusCode) Post<T>(string getEndpoint, object body)
        {
            var response = _httpClient.PostAsJsonAsync(getEndpoint, body);

            var responseData = response.Result.Content.ReadAsStringAsync().Result;

            return (JsonConvert.DeserializeObject<T>(responseData), response.Result.StatusCode);
        }

        public (T, HttpStatusCode) Post<T>(string getEndpoint)
        {
            _httpRequest.RequestUri = new Uri(_httpClient.BaseAddress, getEndpoint);
            _httpRequest.Method = HttpMethod.Post;

            var response = _httpClient.SendAsync(_httpRequest).GetAwaiter().GetResult();

            var responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return (JsonConvert.DeserializeObject<T>(responseData), response.StatusCode);
        }

        public (T, HttpStatusCode) Put<T>(string getEndpoint, object body)
        {
            var response = _httpClient.PutAsJsonAsync(getEndpoint, body);

            var responseData = response.Result.Content.ReadAsStringAsync().Result;

            return (JsonConvert.DeserializeObject<T>(responseData), response.Result.StatusCode);
        }

        public (T, HttpStatusCode) Put<T>(string getEndpoint)
        {
            _httpRequest.RequestUri = new Uri(_httpClient.BaseAddress, getEndpoint);
            _httpRequest.Method = HttpMethod.Put;

            var response = _httpClient.SendAsync(_httpRequest).GetAwaiter().GetResult();

            var responseData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            return (JsonConvert.DeserializeObject<T>(responseData), response.StatusCode);
        }

        public void Put(string url, object body, List<KeyValuePair<string, string>> headers)
        {
            _httpRequest.RequestUri = new Uri(_httpClient.BaseAddress, url);
            _httpRequest.Method = HttpMethod.Put;
            headers.ForEach(x => _httpRequest.Headers.Add(x.Key, x.Value));
            _httpRequest.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            _httpClient.SendAsync(_httpRequest).GetAwaiter().GetResult();
        }

    }
}
