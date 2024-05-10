using Core.Helpers;
using Core.Models;
using ApiSteps = API.Business.Steps.HttpClientSteps.ApiSteps;

namespace API.Tests.HttpClientTests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected Settings settings = SettingHelper.LoadFromAppSettings();
        protected const string incorrectProject = "1";
        protected const int launchNumber = 14;
        protected ApiSteps apiSteps;

        [SetUp]
        public void SetUp()
        {
            TokenRequestModel tokenRequest = new TokenRequestModel
            {
                BaseUrl = settings.ReportPortalUrl.LocalBaseUrl,
                Username = settings.SuperadminUser.UserName,
                Password = settings.SuperadminUser.Password
            };
            var token = TokenServiceHttpClient.GenerateToken(tokenRequest);
            apiSteps = new ApiSteps(settings.ReportPortalUrl.LocalBaseUrl, token);
        }

        [TearDown]
        public void TearDown()
        {
            apiSteps.CleanUp();
        }
    }
}
