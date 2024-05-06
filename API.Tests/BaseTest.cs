using API.Business.Controllers;
using Core.Helpers;
using Core.Models;
using RestSharp;

namespace API.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected Settings settings = SettingHelper.LoadFromAppSettings();
        protected RestClient client;
        protected const string incorrectProject = "1";
        protected const int launchNumber = 14;

        [SetUp]
        public void SetUp()
        {
            TokenRequestModel tokenRequest = new TokenRequestModel
            {
                BaseUrl = settings.ReportPortalUrl.LocalBaseUrl,
                Username = settings.SuperadminUser.UserName,
                Password = settings.SuperadminUser.Password
            };
            var token = TokenService.GenerateToken(tokenRequest);

            client = new RestClient(settings.ReportPortalUrl.LocalBaseUrl);
            client.AddDefaultAuthToken(token);
        }

        [TearDown]
        public void TearDown()
        {
            client.Dispose();
        }
    }
}
