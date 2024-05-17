using Core.HttpClient;
using Core.Models;

namespace API.Business.Steps.RestSharpSteps
{
    public partial class ApiSteps
    {
        private IHttpClient _apiSteps;

        public ApiSteps(string type,TokenRequestModel tokenRequest)
        {
            switch (type)
            {
                case "RestSharp":
                    _apiSteps = new RestClient(tokenRequest);
                    break;

                case "HttpClient":
                    _apiSteps = new ClientOfHttp(tokenRequest);
                    break;

                default:
                    throw new ArgumentException("Incorrect BrowserName");
            }
        }

        public void CleanUp()
        {
            _apiSteps.CleanUp();
        }
    }
}
