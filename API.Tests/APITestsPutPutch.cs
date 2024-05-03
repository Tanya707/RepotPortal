using System.Net;
using API.Business.Models;
using API.Business.Models.Requests;
using API.Business.Models.Responses;
using API.Business.Models.Responses.Items;
using Core.Helpers;
using Core.Models;
using Newtonsoft.Json;
using RestSharp;

namespace API.Tests
{
    public class APITestsPutPatch:BaseTest
    {
        [Test]
        public void API_PutPatch_LaunchStop_Ok()
        {
            var getEndpoint = string.Format(Endpoints.GetLaunchesByFilter, settings.NameOfProject);
            RestRequest requestGet = new RestRequest(getEndpoint, Method.Get);
            var responseGet = client.Execute(requestGet);
            var contentGet = JsonConvert.DeserializeObject<GetLaunchesResponse>(responseGet.Content);

            List<Execution> inProgressExecutions = new List<Execution>();

            foreach (var execution in contentGet.Content)
            {
                if (execution.Status == "IN_PROGRESS")
                {
                    inProgressExecutions.Add(execution);
                }
            }

            var putEndpoint = string.Format(Endpoints.PutLaunchesStop, settings.NameOfProject, inProgressExecutions.First().Id);
            RestRequest request = new RestRequest(putEndpoint, Method.Put);
            var requestBody = new PutLaunchesStopRequest
            {
                EndTime = DateTime.UtcNow,
            };
            request.AddJsonBody(requestBody);

            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<PutLaunchesStopResponse>(response.Content);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.AreEqual(content.Message, $"Launch with ID = '{inProgressExecutions.First().Id}' successfully stopped.");
            });
        }

        [Test]
        public void API_PutPatch_LaunchStop_NotFound()
        {
            var putEndpoint = string.Format(Endpoints.PutLaunchesStop, "1", 14);
            RestRequest requestPut = new RestRequest(putEndpoint, Method.Put);

            var requestBody = new PutLaunchesStopRequest
            {
                EndTime = DateTime.UtcNow,
            };
            requestPut.AddJsonBody(requestBody);
            var response = client.Execute(requestPut);
            var content = JsonConvert.DeserializeObject<BadRequestResponse>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.AreEqual(content.Message, $"Project '1' not found. Did you use correct project name?");
            });
        }

        [Test]
        public void API_PutPatch_LaunchStop_BadRequest()
        {
            var putEndpoint = string.Format(Endpoints.PutLaunchesStop, settings.NameOfProject, 14);
            RestRequest request = new RestRequest(putEndpoint, Method.Put);
            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<BadRequestResponse>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.IsTrue(content.Message.Contains("Incorrect Request."));
            });
        }
    }
}