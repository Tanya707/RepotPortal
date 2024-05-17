using API.Business.Models.Requests;
using API.Business.Models.Responses;
using System.Net;

namespace API.Tests
{
    public class APITestsPost : BaseTest
    {

        [Test]
        public void API_Post_Launches_Ok()
        {
            var requestBody = new PostLaunchesRequest
            {
                Name = "Demo Api Tests",
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

        [Test]
        public void API_Post_Launches_NotFound()
        {
            var requestBody = new PostLaunchesRequest
            {
                Name = "Demo Api Tests",
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