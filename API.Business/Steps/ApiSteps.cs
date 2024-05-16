using Core.Models;
using RestClient = Core.HttpClient.ClientOfHttp;

namespace API.Business.Steps.RestSharpSteps
{
    public partial class ApiSteps
    {
        private RestClient _apiSteps;

        public ApiSteps(TokenRequestModel tokenRequest)
        {
            _apiSteps = new RestClient(tokenRequest);
        }

        public void CleanUp()
        {
            _apiSteps.CleanUp();
        }
    }
}
