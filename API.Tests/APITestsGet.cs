using API.Business.Models;
using API.Business.Steps;
using Core.Helpers;
using Core.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using API.Business.Models.Responses;

namespace API.Tests
{
    public class APITestsGet
    {
        private Settings _settings = SettingHelper.LoadFromAppSettings();

        [TestCase("DEMO2")]
        public void API_Get_Launches_Ok(string nameOfProject)
        { 
            var endpoint = string.Format(Endpoints.GetLaunchesByFilter, nameOfProject);
            var authenticatedClient = new AuthenticatedRestClient(_settings.ReportPortalUrl.LocalBaseUrl, _settings.SuperadminUser.UserName, _settings.SuperadminUser.Password);
            RestRequest request = new RestRequest(endpoint, Method.Get);
            var response = authenticatedClient.Execute(request);
            var content = JsonConvert.DeserializeObject<GetLaunchesResponse>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK)); 
                Assert.AreEqual(content.Content.First().Owner, _settings.SuperadminUser.UserName);
            });
        }

        [TestCase("1")]
        public void API_Get_Launches_NotFound(string nameOfProject)
        {
            var endpoint = string.Format(Endpoints.GetLaunchesByFilter, nameOfProject);
            var authenticatedClient = new AuthenticatedRestClient(_settings.ReportPortalUrl.LocalBaseUrl, _settings.SuperadminUser.UserName, _settings.SuperadminUser.Password);
            RestRequest request = new RestRequest(endpoint, Method.Get);
            var response = authenticatedClient.Execute(request);
            var content = JsonConvert.DeserializeObject<BadRequestResponse>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound)); 
                Assert.AreEqual(content.Message, $"Project '{nameOfProject}' not found. Did you use correct project name?");
            });
        }
    }
}