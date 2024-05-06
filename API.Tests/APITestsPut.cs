using System.Net;
using API.Business.Models;
using API.Business.Models.Enums;
using API.Business.Models.Requests;
using API.Business.Models.Requests.Items;
using API.Business.Models.Responses;
using API.Business.Models.Responses.Items;
using Newtonsoft.Json;
using RestSharp;

namespace API.Tests
{
    public class APITestsPut:BaseTest
    {

        [Test]
        public void API_Put_LaunchStop_Ok()
        {
            var getEndpoint = string.Format(Endpoints.GetLaunchesByFilter, settings.NameOfProject);
            RestRequest requestGet = new RestRequest(getEndpoint, Method.Get);
            var responseGet = client.Execute(requestGet);
            var contentGet = JsonConvert.DeserializeObject<GetLaunchesResponse>(responseGet.Content);

            List<Execution> inProgressExecutions = new List<Execution>();

            foreach (var execution in contentGet.Content)
            {
                if (execution.Status == Status.IN_PROGRESS.ToString())
                {
                    inProgressExecutions.Add(execution);
                }
            }

            var endpointPut = string.Format(Endpoints.PutLaunchesStop, settings.NameOfProject, inProgressExecutions.First().Id);
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
                Status = Status.PASSED.ToString()
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
        public void API_Put_LaunchStop_NotFound()
        {
            var putEndpoint = string.Format(Endpoints.PutLaunchesStop, incorrectProject, launchNumber);
            RestRequest requestPut = new RestRequest(putEndpoint, Method.Put);
            var requestBody = new PutLaunchesStopRequest
            {
                Attributes = new List<AttributeItems>
                {
                    new AttributeItems { Key = "string", System = false, Value = "string" }
                },
                Description = "string",
                EndTime = DateTime.UtcNow,
                Status = Status.PASSED.ToString()
            };
            requestPut.AddJsonBody(requestBody);
            var response = client.Execute(requestPut);
            var content = JsonConvert.DeserializeObject<BadRequestResponse>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.AreEqual(content.Message, $"Project '{incorrectProject}' not found. Did you use correct project name?");
            });
        }

        [Test]
        public void API_Put_LaunchStop_BadRequest()
        {
            var putEndpoint = string.Format(Endpoints.PutLaunchesStop, settings.NameOfProject, launchNumber);
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