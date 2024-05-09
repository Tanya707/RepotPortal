using API.Business.Models.Responses;
using System.Net;

namespace API.Tests.RestSharpTests
{
    public class APITestsGet : BaseTest
    {
        [Test]
        public void API_Get_Launches_Ok()
        {
            var (data, statusCode) = apiSteps.GetLaunchesResponse<GetLaunchesResponse>(settings.NameOfProject);

            Assert.Multiple(() =>
            {
                Assert.That(statusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.AreEqual(data.Content.First().Owner, settings.SuperadminUser.UserName);
            });
        }

        [Test]
        public void API_Get_Launches_NotFound()
        {
            var (data, statusCode) = apiSteps.GetLaunchesResponse<BadRequestResponse>(incorrectProject);

            Assert.Multiple(() =>
            {
                Assert.That(statusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.AreEqual(data.Message, $"Project '{incorrectProject}' not found. Did you use correct project name?");
            });
        }
    }
}