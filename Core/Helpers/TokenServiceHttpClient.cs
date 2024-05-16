using Newtonsoft.Json;
using Core.Models;
using System.Text;

namespace Core.Helpers
{
    public static class TokenServiceHttpClient
    {
        public static string GenerateToken(TokenRequestModel tokenRequest)
        {
            var client = new System.Net.Http.HttpClient();
            client.BaseAddress = new Uri(tokenRequest.BaseUrl);
            var request = new HttpRequestMessage(HttpMethod.Post, "uat/sso/oauth/token");

            request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("ui:uiman"));
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);

            var requestBody = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", tokenRequest.Username),
                new KeyValuePair<string, string>("password", tokenRequest.Password)
            });
            request.Content = requestBody;

            var response = client.SendAsync(request).Result;
            
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
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
