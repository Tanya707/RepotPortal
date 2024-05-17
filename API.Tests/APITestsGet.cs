using API.Business.Models.Responses;
using System.Net;
using API.Business.Models.Requests;

namespace API.Tests
{
    public class APITestsGet : BaseTest
    {
        [Test]
        public void API_Get_Launches_Ok()
        {
            var request = new ApiRequest
            {
                NameOfProject = settings.NameOfProject,
            };

            var (data, statusCode) = apiSteps.GetLaunchesResponse<GetLaunchesResponse>(request);

            Assert.Multiple(() =>
            {
                Assert.That(statusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(data.Content.First().Owner, Is.EqualTo(settings.SuperadminUser.UserName));
            });
        }

        [Test]
        public void API_Get_Launches_NotFound()
        {
            var request = new ApiRequest
            {
                NameOfProject = incorrectProject,
            };
            var (data, statusCode) = apiSteps.GetLaunchesResponse<BadRequestResponse>(request);

            Assert.Multiple(() =>
            {
                Assert.That(statusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(data.Message, Is.EqualTo($"Project '{incorrectProject}' not found. Did you use correct project name?"));
            });
        }
    }
}