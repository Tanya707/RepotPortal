using Core.Helpers;
using Core.Models;
using ApiSteps = API.Business.Steps.RestSharpSteps.ApiSteps;

namespace API.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected Settings settings = SettingHelper.LoadFromAppSettings();
        protected const string incorrectProject = "1";
        protected const int launchNumber = 14;
        protected ApiSteps apiSteps;
        protected ConfigSettings configs = SettingHelper.LoadFromConfigSettings();

        [SetUp]
        public void SetUp()
        {
            TokenRequestModel tokenRequest = new TokenRequestModel
            {
                BaseUrl = settings.ReportPortalUrl.LocalBaseUrl,
                Username = settings.SuperadminUser.UserName,
                Password = settings.SuperadminUser.Password
            };
            apiSteps = new ApiSteps(configs.ApiClient, tokenRequest);
        }

        [TearDown]
        public void TearDown()
        {
            apiSteps.CleanUp();
        }
    }
}
