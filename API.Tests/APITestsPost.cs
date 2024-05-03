using API.Business.Models;
using API.Business.Models.Responses;
using Core.Helpers;
using Core.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using API.Business.Models.Requests;

namespace API.Tests
{
    public class APITestsPost:BaseTest
    {

        [TestCase("Demo Api Tests")]
        public void API_Post_Launches_Ok(string nameOfLaunch)
        {
            var postEndpoint = string.Format(Endpoints.GetLaunchesByFilter, settings.NameOfProject);
            
            RestRequest request = new RestRequest(postEndpoint, Method.Post);
            var requestBody = new PostLaunchesRequest
            {
                Name = nameOfLaunch,
                StartTime = DateTime.UtcNow
            };
            request.AddJsonBody(requestBody);

            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<PostLaunchesResponse>(response.Content);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
                Assert.IsNotEmpty(content.Id);
                Assert.IsNotNull(content.Number);
            });
        }

        [TestCase( "Demo Api Tests")]
        public void API_Post_Launches_NotFound(string nameOfLaunch)
        {
            var postEndpoint = string.Format(Endpoints.GetLaunchesByFilter, "1");

            RestRequest request = new RestRequest(postEndpoint, Method.Post);
            var requestBody = new PostLaunchesRequest
            {
                Name = nameOfLaunch,
                StartTime = DateTime.UtcNow
            };
            request.AddJsonBody(requestBody);
            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<BadRequestResponse>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.AreEqual(content.Message, $"Project '1' not found. Did you use correct project name?");
            });
        }


        [Test]
        public void API_Post_Launches_BadRequest()
        {
            var postEndpoint = string.Format(Endpoints.GetLaunchesByFilter, settings.NameOfProject);
            RestRequest request = new RestRequest(postEndpoint, Method.Post);
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