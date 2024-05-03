using System.Net;
using API.Business.Models;
using API.Business.Models.Requests;
using API.Business.Models.Responses;
using Core.Helpers;
using Core.Models;
using Newtonsoft.Json;
using RestSharp;

namespace API.Tests
{
    public class APITestsDelete:BaseTest
    {
        [Test]
        public void API_Delete_Launches_Ok()
        {
            var getEndpoint = string.Format(Endpoints.GetLaunchesByFilter, settings.NameOfProject);
            RestRequest request = new RestRequest(getEndpoint, Method.Get);
            var responseGet = client.Execute(request);
            var contentGet = JsonConvert.DeserializeObject<GetLaunchesResponse>(responseGet.Content);

            var deleteEndpoint = string.Format(Endpoints.GetLaunchesByFilter, settings.NameOfProject);
            RestRequest requestDelete = new RestRequest(deleteEndpoint, Method.Delete);
            var requestBodyDelete = new DeleteLaunchesRequest
            {
                Ids = new List<int> { contentGet.Content.First().Id }
            };
            requestDelete.AddJsonBody(requestBodyDelete);
            var responseDelete = client.Execute(requestDelete);
            var contentDelete = JsonConvert.DeserializeObject<DeleteLaunchesResponse>(responseDelete.Content);

            Assert.Multiple(() =>
            {
                Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.AreEqual(contentDelete.SuccessfullyDeleted.First(), contentGet.Content.First().Id);
            });
        }

        [Test]
        public void API_Delete_Launches_NotFound()
        {
            var deleteEndpoint = string.Format(Endpoints.GetLaunchesByFilter, "1");
            RestRequest requestDelete = new RestRequest(deleteEndpoint, Method.Delete);
            
            var requestBodyDelete = new DeleteLaunchesRequest
            {
                Ids = new List<int> { 13 }
            };
            requestDelete.AddJsonBody(requestBodyDelete);
            var responseDelete = client.Execute(requestDelete);
            var contentDelete = JsonConvert.DeserializeObject<BadRequestResponse>(responseDelete.Content);

            Assert.Multiple(() =>
            {
                Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.AreEqual(contentDelete.Message, $"Project '1' not found. Did you use correct project name?");
            });
        }


        [Test]
        public void API_Delete_Launches_BadRequest()
        {
            var deleteEndpoint = string.Format(Endpoints.GetLaunchesByFilter, settings.NameOfProject);
            RestRequest requestDelete = new RestRequest(deleteEndpoint, Method.Delete);
            var responseDelete = client.Execute(requestDelete);
            var contentDelete = JsonConvert.DeserializeObject<BadRequestResponse>(responseDelete.Content);

            Assert.Multiple(() =>
            {
                Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.IsTrue(contentDelete.Message.Contains("Incorrect Request."));
            });
        }
    }
}