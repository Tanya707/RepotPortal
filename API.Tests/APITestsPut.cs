using System.Net;
using API.Business.Models.Enums;
using API.Business.Models.Requests;
using API.Business.Models.Requests.Items;
using API.Business.Models.Responses;

namespace API.Tests
{
    public class APITestsPut : BaseTest
    {

        [Test]
        public void API_Put_LaunchStop_Ok()
        {
            var (dataGet, _) = apiSteps.GetLaunchesResponse<GetLaunchesResponse>(settings.NameOfProject);
            var inProgressExecutions = apiSteps.InProgressExecutions(dataGet);

            var requestBody = new PutLaunchesStopRequest
            {
                Attributes = new List<AttributeItems>
                {
                    new AttributeItems {
                        Key = "Environment",
                        System = false,
                        Value = "12" }
                },
                Description = dataGet.Content.First().Description,
                EndTime = DateTime.UtcNow,
                Status = Status.PASSED.ToString()
            };

            var (dataPut, statusCodePut) = apiSteps.PutLaunchesStopResponse<PutLaunchesStopResponse>(settings.NameOfProject, inProgressExecutions.First().Id, requestBody);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodePut, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(dataPut.Message, Is.EqualTo($"Launch with ID = '{inProgressExecutions.First().Id}' successfully stopped."));
            });
        }

        [Test]
        public void API_Put_LaunchStop_NotFound()
        {
            var requestBody = new PutLaunchesStopRequest
            {
                Attributes = new List<AttributeItems>
                {
                    new AttributeItems
                    {
                        Key = "Environment",
                        System = false,
                        Value = "12"
                    }
                },
                Description = "string",
                EndTime = DateTime.UtcNow,
                Status = Status.PASSED.ToString()
            };

            var (dataPut, statusCodePut) = apiSteps.PutLaunchesStopResponse<BadRequestResponse>(incorrectProject, launchNumber, requestBody);


            Assert.Multiple(() =>
            {
                Assert.That(statusCodePut, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(dataPut.Message, Is.EqualTo($"Project '{incorrectProject}' not found. Did you use correct project name?"));
            });
        }

        [Test]
        public void API_Put_LaunchStop_BadRequest()
        {
            var (dataPut, statusCodePut) = apiSteps.PutLaunchesStopResponse<BadRequestResponse>(settings.NameOfProject, launchNumber);

            Assert.Multiple(() =>
            {
                Assert.That(statusCodePut, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.IsTrue(dataPut.Message.Contains("Incorrect Request."));
            });
        }
    }
}