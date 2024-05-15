using API.Business.Controllers;


namespace API.Business.Steps.HttpClientSteps
{
    public partial class ApiSteps
    {

        private HttpClient _client;
        private HttpRequestMessage _request;

        public ApiSteps(string baseUrl, string token)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
            _client.AddDefaultHttpAuthToken(token);
            _request = new HttpRequestMessage();
        }

        public void CleanUp()
        {
            _client.CancelPendingRequests();
            _client.Dispose();
        }
    }
}
