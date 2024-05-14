using API.Business.Models.Responses;
using System.Net;

namespace API.Tests.RestSharpTests
{
    public class APITestsDelete : BaseTest
    {
        [Test]
        public void API_Delete_Launches_Ok()
        {
            var (dataGet, _) = apiSteps.GetLaunchesResponse<GetLaunchesResponse>(settings.NameOfProject);

            var (dataDelete, statusCodeDelete) = apiSteps.DeleteLaunchesResponse<DeleteLaunchesResponse>(settings.NameOfProject, dataGet.Content.First().Id);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodeDelete, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(dataDelete.Message, Is.EqualTo($"Launch with ID = '{dataGet.Content.First().Id}' successfully deleted."));
            });
        }

        [Test]
        public void API_Delete_Launches_NotFound()
        {
            var (dataDelete, statusCodeDelete) = apiSteps.DeleteLaunchesResponse<BadRequestResponse>(incorrectProject, launchNumber);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodeDelete, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(dataDelete.Message, Is.EqualTo($"Project '{incorrectProject}' not found. Did you use correct project name?"));
            });
        }

    }
}