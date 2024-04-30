using RestSharp;
using Newtonsoft.Json;

namespace Core.Helpers
{
    public static class TokenService
    {
        public static string GenerateToken(string baseUrl, string username, string password)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest("uat/sso/oauth/token", Method.Post);

            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Basic " + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes("ui:uiman")));

            request.AddParameter("grant_type", "password");
            request.AddParameter("username", username);
            request.AddParameter("password", password);

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
