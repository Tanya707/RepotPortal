using API.Business.Models.Requests;
using API.Business.Models.Requests.Items;
using API.Business.Models.Responses;
using System.Net;

namespace API.Tests
{
    public class APITestsPutPatch : BaseTest
    {
        [Test]
        public void API_PutPatch_LaunchUpdate_Ok()
        {
            var requestForGet = new ApiRequest
            {
                NameOfProject = settings.NameOfProject,
            };

            var (dataGet, _) = apiSteps.GetLaunchesResponse<GetLaunchesResponse>(requestForGet);
            var interruptedExecutions = apiSteps.InterruptedExecutions(dataGet);

            var requestBody = new PatchLaunchesUpdateRequest
            {
                Attributes = new List<AttributeItems>
                {
                    new AttributeItems {
                        Key = "Environment",
                        Value = "13" }
                },
            };

            var request = new ApiRequest
            {
                NameOfProject = settings.NameOfProject,
                LaunchNumber = interruptedExecutions.First().Id,
                BodyOfRequest = requestBody
            };

            var (dataPatch, statusCodePatch) = apiSteps.PatchLaunchesUpdateResponse<PatchLaunchesUpdateResponse>(request);
            var (dataGetAfterPatch, _) = apiSteps.GetLaunchesResponse<GetLaunchesResponse>(requestForGet);
            var executionsById = apiSteps.ExecutionsById(dataGetAfterPatch, interruptedExecutions.First().Id);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodePatch, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(dataPatch.Message, Is.EqualTo($"Launch with ID = '{interruptedExecutions.First().Id}' successfully updated."));
                Assert.That(executionsById.First().Attributes.First().Key, Is.EqualTo("Environment"));
                Assert.That(executionsById.First().Attributes.First().Value, Is.EqualTo("13"));
            });
        }

        [Test]
        public void API_PutPatch_LaunchStop_NotFound()
        {
            var requestBody = new PatchLaunchesUpdateRequest
            {
                Attributes = new List<AttributeItems>
                {
                    new AttributeItems {
                        Key = "Environment",
                        Value = "1" }
                },
            };

            var request = new ApiRequest
            {
                NameOfProject = incorrectProject,
                LaunchNumber = launchNumber,
                BodyOfRequest = requestBody
            };

            var (dataPatch, statusCodePatch) = apiSteps.PatchLaunchesUpdateResponse<BadRequestResponse>(request);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodePatch, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(dataPatch.Message, Is.EqualTo($"Project '{incorrectProject}' not found. Did you use correct project name?"));
            });
        }

        [Test]
        public void API_PutPatch_LaunchStop_BadRequest()
        {
            var request = new ApiRequest
            {
                NameOfProject = settings.NameOfProject,
                LaunchNumber = launchNumber,
            };

            var (dataPatch, statusCodePatch) = apiSteps.PatchLaunchesUpdateResponseBadRequest<BadRequestResponse>(request);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodePatch, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.IsTrue(dataPatch.Message.Contains("Incorrect Request."));
            });
        }
    }
}