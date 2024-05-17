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
            var requestForGet = new ApiRequest
            {
                NameOfProject = settings.NameOfProject,
            };

            var (dataGet, _) = apiSteps.GetLaunchesResponse<GetLaunchesResponse>(requestForGet);

            var requestBody = new PostLaunchesRequest
            {
                Name = "Demo Api Tests",
                StartTime = DateTime.UtcNow
            };

            var request = new ApiRequest
            {
                NameOfProject = settings.NameOfProject,
                BodyOfRequest = requestBody
            };

            var (data, statusCode) = apiSteps.PostLaunchesResponse<PostLaunchesResponse>(request);
            var (dataGetAfterPost, _) = apiSteps.GetLaunchesResponse<GetLaunchesResponse>(requestForGet);

            Assert.Multiple(() =>
            {
                Assert.That(statusCode, Is.EqualTo(HttpStatusCode.Created));
                Assert.IsNotEmpty(data.Id);
                Assert.IsNotNull(data.Number);
                Assert.False(dataGet.Content.Count== dataGetAfterPost.Content.Count);
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

            var request = new ApiRequest
            {
                NameOfProject = incorrectProject,
                BodyOfRequest = requestBody
            };

            var (data, statusCode) = apiSteps.PostLaunchesResponse<BadRequestResponse>(request);

            Assert.Multiple(() =>
            {
                Assert.That(statusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.AreEqual(data.Message, $"Project '{incorrectProject}' not found. Did you use correct project name?");
            });
        }


        [Test]
        public void API_Post_Launches_BadRequest()
        {
            var request = new ApiRequest
            {
                NameOfProject = settings.NameOfProject,
            };

            var (data, statusCode) = apiSteps.PostLaunchesResponseBadRequest<BadRequestResponse>(request);

            Assert.Multiple(() =>
            {
                Assert.That(statusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.IsTrue(data.Message.Contains("Incorrect Request."));
            });
        }
    }
}