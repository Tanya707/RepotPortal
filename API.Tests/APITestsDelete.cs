using API.Business.Models.Requests;
using API.Business.Models.Responses;
using System.Net;

namespace API.Tests
{
    public class APITestsDelete : BaseTest
    {
        [Test]
        public void API_Delete_Launches_Ok()
        {
            var requestForGet = new ApiRequest
            {
                NameOfProject = settings.NameOfProject,
            };

            var (dataGet, _) = apiSteps.GetLaunchesResponse<GetLaunchesResponse>(requestForGet);
            var request = new ApiRequest
            {
                NameOfProject = settings.NameOfProject,
                LaunchNumber = dataGet.Content.First().Id
            };

            var (dataDelete, statusCodeDelete) = apiSteps.DeleteLaunchesResponse<DeleteLaunchesResponse>(request);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodeDelete, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(dataDelete.Message, Is.EqualTo($"Launch with ID = '{dataGet.Content.First().Id}' successfully deleted."));
            });
        }

        [Test]
        public void API_Delete_Launches_NotFound()
        {
            var request = new ApiRequest
            {
                NameOfProject = incorrectProject,
                LaunchNumber = launchNumber
            };
            var (dataDelete, statusCodeDelete) = apiSteps.DeleteLaunchesResponse<BadRequestResponse>(request);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodeDelete, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(dataDelete.Message, Is.EqualTo($"Project '{incorrectProject}' not found. Did you use correct project name?"));
            });
        }

    }
}