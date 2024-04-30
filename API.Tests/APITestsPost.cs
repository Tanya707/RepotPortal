using API.Business.Models;
using API.Business.Steps;
using Core.Helpers;
using Core.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using API.Business.Models.Responses;
using API.Business.Models.Requests;

namespace API.Tests
{
    public class APITestsPost
    {
        private Settings _settings = SettingHelper.LoadFromAppSettings();

        [TestCase("DEMO2", "Demo Api Tests")]
        public void API_Post_Launches_Ok(string nameOfProject, string nameOfLaunch)
        { 
            var endpoint = string.Format(Endpoints.GetLaunchesByFilter, nameOfProject);
            var authenticatedClient = new AuthenticatedRestClient(_settings.ReportPortalUrl.LocalBaseUrl, _settings.SuperadminUser.UserName, _settings.SuperadminUser.Password);
            RestRequest request = new RestRequest(endpoint, Method.Post);
            var requestBody = new 
            {
                Name = nameOfLaunch,
                StartTime = DateTime.UtcNow
            };
            request.AddJsonBody(requestBody);

            var response = authenticatedClient.Execute(request);
            var content = JsonConvert.DeserializeObject<PostLaunchesResponse>(response.Content);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created)); 
                Assert.IsNotEmpty(content.Id); 
                Assert.IsNotNull(content.Number);
            });
        }

        [TestCase("1", "Demo Api Tests")]
        public void API_Post_Launches_NotFound(string nameOfProject, string nameOfLaunch)
        {
            var endpoint = string.Format(Endpoints.GetLaunchesByFilter, nameOfProject);
            var authenticatedClient = new AuthenticatedRestClient(_settings.ReportPortalUrl.LocalBaseUrl, _settings.SuperadminUser.UserName, _settings.SuperadminUser.Password);
            RestRequest request = new RestRequest(endpoint, Method.Post);
            var requestBody = new PostLaunchesRequest
            {
                Name = nameOfLaunch,
                StartTime = DateTime.UtcNow
            };
            request.AddJsonBody(requestBody);
            var response = authenticatedClient.Execute(request);
            var content = JsonConvert.DeserializeObject<BadRequestResponse>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound)); 
                Assert.AreEqual(content.Message, $"Project '{nameOfProject}' not found. Did you use correct project name?");
            });
        }


        [TestCase("DEMO2")]
        public void API_Post_Launches_BadRequest(string nameOfProject)
        {
            var endpoint = string.Format(Endpoints.GetLaunchesByFilter, nameOfProject);
            var authenticatedClient = new AuthenticatedRestClient(_settings.ReportPortalUrl.LocalBaseUrl, _settings.SuperadminUser.UserName, _settings.SuperadminUser.Password);
            RestRequest request = new RestRequest(endpoint, Method.Post);
            var response = authenticatedClient.Execute(request);
            var content = JsonConvert.DeserializeObject<BadRequestResponse>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.IsTrue(content.Message.Contains("Incorrect Request."));
            });
        }
    }
}