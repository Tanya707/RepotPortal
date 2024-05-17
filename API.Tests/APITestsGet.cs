using API.Business.Models.Responses;
using System.Net;

namespace API.Tests
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
                Assert.That(data.Content.First().Owner, Is.EqualTo(settings.SuperadminUser.UserName));
            });
        }

        [Test]
        public void API_Get_Launches_NotFound()
        {
            var (data, statusCode) = apiSteps.GetLaunchesResponse<BadRequestResponse>(incorrectProject);

            Assert.Multiple(() =>
            {
                Assert.That(statusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(data.Message, Is.EqualTo($"Project '{incorrectProject}' not found. Did you use correct project name?"));
            });
        }
    }
}