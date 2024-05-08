using API.Business.Models;
using API.Business.Models.Requests;
using API.Business.Models.Requests.Items;
using API.Business.Models.Responses;
using RestSharp;
using System.Net;

namespace API.Tests
{
    public class APITestsPutPatch : BaseTest
    {
        [Test]
        public void API_PutPatch_LaunchUpdate_Ok()
        {
            var (dataGet, statusCodeGet) = apiSteps.GetLaunchesResponse<GetLaunchesResponse>(settings.NameOfProject);
            var inProgressExecutions = apiSteps.InProgressExecutions(dataGet);

            var requestBody = new PatchLaunchesUpdateRequest
            {
                Attributes = new List<AttributeItems>
                {
                    new AttributeItems {
                        Key = "Environment",
                        Value = "1" }
                },
            };

            var (dataPatch, statusCodePatch) = apiSteps.PatchLaunchesUpdateResponse<PatchLaunchesUpdateResponse>(settings.NameOfProject, inProgressExecutions.First().Id, requestBody);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodePatch, Is.EqualTo(HttpStatusCode.OK));
                Assert.AreEqual(dataPatch.Message, $"Launch with ID = '{inProgressExecutions.First().Id}' successfully updated.");
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

            var (dataPatch, statusCodePatch) = apiSteps.PatchLaunchesUpdateResponse<BadRequestResponse>(incorrectProject, launchNumber, requestBody);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodePatch, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.AreEqual(dataPatch.Message, $"Project '{incorrectProject}' not found. Did you use correct project name?");
            });
        }

        [Test]
        public void API_PutPatch_LaunchStop_BadRequest()
        {
            var (dataPatch, statusCodePatch) = apiSteps.PatchLaunchesUpdateResponse<BadRequestResponse>(settings.NameOfProject, launchNumber);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodePatch, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.IsTrue(dataPatch.Message.Contains("Incorrect Request."));
            });
        }
    }
}