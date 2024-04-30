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
    public class APITestsDelete
    {
        private Settings _settings = SettingHelper.LoadFromAppSettings();

        [TestCase("DEMO2")]
        public void API_Delete_Launches_Ok(string nameOfProject)
        { 
            var endpoint = string.Format(Endpoints.GetLaunchesByFilter, nameOfProject);
            var authenticatedClient = new AuthenticatedRestClient(_settings.ReportPortalUrl.LocalBaseUrl, _settings.SuperadminUser.UserName, _settings.SuperadminUser.Password);
            RestRequest requestGet = new RestRequest(endpoint, Method.Get);
            var responseGet = authenticatedClient.Execute(requestGet);
            var contentGet = JsonConvert.DeserializeObject<GetLaunchesResponse>(responseGet.Content);

            RestRequest requestDelete = new RestRequest(endpoint, Method.Delete);
            var requestBodyDelete = new DeleteLaunchesRequest
            {
                Ids = new List<int> { contentGet.Content.First().Id }
            };
            requestDelete.AddJsonBody(requestBodyDelete);
            var responseDelete = authenticatedClient.Execute(requestDelete);
            var contentDelete = JsonConvert.DeserializeObject<DeleteLaunchesResponse>(responseDelete.Content);

            Assert.Multiple(() =>
            {
                Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.OK)); 
                Assert.AreEqual(contentDelete.SuccessfullyDeleted.First(), contentGet.Content.First().Id);
            });
        }

        [TestCase("1")]
        public void API_Delete_Launches_NotFound(string nameOfProject)
        {
            var endpoint = string.Format(Endpoints.GetLaunchesByFilter, nameOfProject);
            var authenticatedClient = new AuthenticatedRestClient(_settings.ReportPortalUrl.LocalBaseUrl, _settings.SuperadminUser.UserName, _settings.SuperadminUser.Password);

            RestRequest requestDelete = new RestRequest(endpoint, Method.Delete);
            var requestBodyDelete = new DeleteLaunchesRequest
            {
                Ids = new List<int> { 13 }
            };
            requestDelete.AddJsonBody(requestBodyDelete);
            var responseDelete = authenticatedClient.Execute(requestDelete);
            var contentDelete = JsonConvert.DeserializeObject<BadRequestResponse>(responseDelete.Content);

            Assert.Multiple(() =>
            {
                Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.AreEqual(contentDelete.Message, $"Project '{nameOfProject}' not found. Did you use correct project name?");
            });
        }


        [TestCase("DEMO2")]
        public void API_Delete_Launches_BadRequest(string nameOfProject)
        {
            var endpoint = string.Format(Endpoints.GetLaunchesByFilter, nameOfProject);
            var authenticatedClient = new AuthenticatedRestClient(_settings.ReportPortalUrl.LocalBaseUrl, _settings.SuperadminUser.UserName, _settings.SuperadminUser.Password);

            RestRequest requestDelete = new RestRequest(endpoint, Method.Delete);
            var responseDelete = authenticatedClient.Execute(requestDelete);
            var contentDelete = JsonConvert.DeserializeObject<BadRequestResponse>(responseDelete.Content);

            Assert.Multiple(() =>
            {
                Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.IsTrue(contentDelete.Message.Contains("Incorrect Request."));
            });
        }
    }
}