
using Newtonsoft.Json;
using Core.Models;
using RestSharp;

namespace Core.Helpers
{
    public static class TokenService
    {
        public static string GenerateToken(TokenRequestModel tokenRequest)
        {
            var client = new RestClient(tokenRequest.BaseUrl);
            var request = new RestRequest("uat/sso/oauth/token", Method.Post);

            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Basic " + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("ui:uiman")));

            request.AddParameter("grant_type", "password");
            request.AddParameter("username", tokenRequest.Username);
            request.AddParameter("password", tokenRequest.Password);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
                string token = jsonResponse.access_token;
                return token;
            }
            else
            {
                throw new Exception($"Failed to generate token. Status code: {response.StatusCode}");
            }
        }
    }
}
