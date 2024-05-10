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

            var (dataDelete, statusCodeDelete) = apiSteps.DeleteLaunchesResponse<DeleteLaunchesResponse>(settings.NameOfProject, dataGet.Content.First().Id);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodeDelete, Is.EqualTo(HttpStatusCode.OK));
                Assert.AreEqual(dataDelete.Message, $"Launch with ID = '{dataGet.Content.First().Id}' successfully deleted.");
            });
        }

        [Test]
        public void API_Delete_Launches_NotFound()
        {
            var (dataDelete, statusCodeDelete) = apiSteps.DeleteLaunchesResponse<BadRequestResponse>(incorrectProject, launchNumber);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodeDelete, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.AreEqual(dataDelete.Message, $"Project '{incorrectProject}' not found. Did you use correct project name?");
            });
        }

    }
}