using API.Business.Models;
using API.Business.Models.Responses;
using Core.Helpers;
using Core.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace API.Tests
{
    public class APITestsGet:BaseTest
    {
        private Settings _settings = SettingHelper.LoadFromAppSettings();

        [Test]
        public void API_Get_Launches_Ok()
        {
            var getEndpoint = string.Format(Endpoints.GetLaunchesByFilter, settings.NameOfProject);
            RestRequest request = new RestRequest(getEndpoint, Method.Get);
            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<GetLaunchesResponse>(response.Content);
            
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK)); 
                Assert.AreEqual(content.Content.First().Owner, _settings.SuperadminUser.UserName);
            });
        }

        [Test]
        public void API_Get_Launches_NotFound()
        {
            var GetEndpoint = string.Format(Endpoints.GetLaunchesByFilter, "1");
            RestRequest request = new RestRequest(GetEndpoint, Method.Get);
            var response = client.Execute(request);
            var content = JsonConvert.DeserializeObject<BadRequestResponse>(response.Content);

            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.AreEqual(content.Message, $"Project '1' not found. Did you use correct project name?");
            });
        }
    }
}