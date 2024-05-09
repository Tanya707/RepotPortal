using API.Business.Models.Requests;
using API.Business.Models.Responses;
using System.Net;

namespace API.Tests.RestSharpTests
{
    public class APITestsDelete : BaseTest
    {
        [Test]
        public void API_Delete_Launches_Ok()
        {
            var (dataGet, statusCodeGet) = apiSteps.GetLaunchesResponse<GetLaunchesResponse>(settings.NameOfProject);

            var requestBodyDelete = new DeleteLaunchesRequest
            {
                Ids = new List<int> { dataGet.Content.First().Id }
            };

            var (dataDelete, statusCodeDelete) = apiSteps.DeleteLaunchesResponse<DeleteLaunchesResponse>(settings.NameOfProject, requestBodyDelete);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodeDelete, Is.EqualTo(HttpStatusCode.OK));
                Assert.AreEqual(dataDelete.SuccessfullyDeleted.First(), dataGet.Content.First().Id);
            });
        }

        [Test]
        public void API_Delete_Launches_NotFound()
        {
            var requestBodyDelete = new DeleteLaunchesRequest
            {
                Ids = new List<int> { 13 }
            };

            var (dataDelete, statusCodeDelete) = apiSteps.DeleteLaunchesResponse<BadRequestResponse>(incorrectProject, requestBodyDelete);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodeDelete, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.AreEqual(dataDelete.Message, $"Project '{incorrectProject}' not found. Did you use correct project name?");
            });
        }


        [Test]
        public void API_Delete_Launches_BadRequest()
        {
            var (dataDelete, statusCodeDelete) = apiSteps.DeleteLaunchesResponse<BadRequestResponse>(settings.NameOfProject);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodeDelete, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.IsTrue(dataDelete.Message.Contains("Incorrect Request."));
            });
        }
    }
}