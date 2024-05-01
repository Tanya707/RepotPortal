using API.Business.Steps;
using Core.Helpers;
using Core.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using API.Business.Models.Responses;
using API.Business.Models.Requests;
using AttributeItems = API.Business.Models.Requests.Items.AttributeItems;
using API.Business.Models.Responses.Items;
using API.Business.Models;

namespace API.Tests
{
    public class APITestsPut
    {
        private Settings _settings = SettingHelper.LoadFromAppSettings();

        [TestCase("DEMO2", 14)]
        public void API_Put_LaunchStop_Ok(string nameOfProject, int launchId)
        {
            var endpointGet = string.Format(Endpoints.GetLaunchesByFilter, nameOfProject);
            var authenticatedClient = new AuthenticatedRestClient(_settings.ReportPortalUrl.LocalBaseUrl, _settings.SuperadminUser.UserName, _settings.SuperadminUser.Password);
            RestRequest requestGet = new RestRequest(endpointGet, Method.Get);
            var responseGet = authenticatedClient.Execute(requestGet);
            var contentGet = JsonConvert.DeserializeObject<GetLaunchesResponse>(responseGet.Content);

            List<Execution> inProgressExecutions = new List<Execution>();

            foreach (var execution in contentGet.Content)
            {
                if (execution.Status == "IN_PROGRESS")
                {
                    inProgressExecutions.Add(execution);
                }
            }

            var endpointPut = string.Format(Endpoints.PutLaunchesStop, nameOfProject, inProgressExecutions.First().Id);
            RestRequest request = new RestRequest(endpointPut, Method.Put);
            var requestBody = new PutLaunchesStopRequest
            {
                Attributes = new List<AttributeItems>
                {
                    new AttributeItems { 
                        Key = "string",
                        System = false, 
                        Value = "string PASSED" }
                },
                Description = contentGet.Content.First().Description,
                EndTime = DateTime.UtcNow,
                Status = "PASSED"
            };
            request.AddJsonBody(requestBody);

            var response = authenticatedClient.Execute(request);
            var content = JsonConvert.DeserializeObject<PutLaunchesStopResponse>(response.Content);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.AreEqual(content.Message, $"Launch with ID = '{inProgressExecutions.First().Id}' successfully stopped.");
            });
        }

        [TestCase("1", 14)]
        public void API_Put_LaunchStop_NotFound(string nameOfProject, int launchId)
        {
            var endpoint = string.Format(Endpoints.PutLaunchesStop, nameOfProject, launchId);
            var authenticatedClient = new AuthenticatedRestClient(_settings.ReportPortalUrl.LocalBaseUrl, _settings.SuperadminUser.UserName, _settings.SuperadminUser.Password);
            RestRequest request = new RestRequest(endpoint, Method.Put);
            var requestBody = new PutLaunchesStopRequest
            {
                Attributes = new List<AttributeItems>
                {
                    new AttributeItems { Key = "string", System = false, Value = "string" }
                },
                Description = "string",
                EndTime = DateTime.UtcNow,
                Status = "PASSED"
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

        [TestCase("DEMO2", 14)]
        public void API_Put_LaunchStop_BadRequest(string nameOfProject, int launchId)
        {
            var endpoint = string.Format(Endpoints.PutLaunchesStop, nameOfProject, launchId);
            var authenticatedClient = new AuthenticatedRestClient(_settings.ReportPortalUrl.LocalBaseUrl, _settings.SuperadminUser.UserName, _settings.SuperadminUser.Password);
            RestRequest request = new RestRequest(endpoint, Method.Put);
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