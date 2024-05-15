using API.Business.Models.Requests;
using API.Business.Models.Responses;
using System.Net;

namespace API.Tests.RestSharpTests
{
    public class APITestsPost : BaseTest
    {

        [TestCase("Demo Api Tests")]
        public void API_Post_Launches_Ok(string nameOfLaunch)
        {
            var requestBody = new PostLaunchesRequest
            {
                Name = nameOfLaunch,
                StartTime = DateTime.UtcNow
            };

            var (data, statusCode) = apiSteps.PostLaunchesResponse<PostLaunchesResponse>(settings.NameOfProject, requestBody);

            Assert.Multiple(() =>
            {
                Assert.That(statusCode, Is.EqualTo(HttpStatusCode.Created));
                Assert.IsNotEmpty(data.Id);
                Assert.IsNotNull(data.Number);
            });
        }

        [TestCase("Demo Api Tests")]
        public void API_Post_Launches_NotFound(string nameOfLaunch)
        {
            var requestBody = new PostLaunchesRequest
            {
                Name = nameOfLaunch,
                StartTime = DateTime.UtcNow
            };

            var (data, statusCode) = apiSteps.PostLaunchesResponse<BadRequestResponse>(incorrectProject, requestBody);

            Assert.Multiple(() =>
            {
                Assert.That(statusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.AreEqual(data.Message, $"Project '{incorrectProject}' not found. Did you use correct project name?");
            });
        }


        [Test]
        public void API_Post_Launches_BadRequest()
        {
            var (data, statusCode) = apiSteps.PostLaunchesResponse<BadRequestResponse>(settings.NameOfProject);

            Assert.Multiple(() =>
            {
                Assert.That(statusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.IsTrue(data.Message.Contains("Incorrect Request."));
            });
        }
    }
}