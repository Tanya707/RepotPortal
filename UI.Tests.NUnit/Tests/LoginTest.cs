
[assembly: LevelOfParallelism(6)]
namespace UI.Tests.NUnit
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]

    public class LoginTest : BaseTestNUnit
    {
        [Test]
        public void LogInButtonDisplayedTest()
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            Assert.IsTrue(loginPage.IsLogInButtonDisplayed(), "Log in button isn't displayed");
        }

        [Test]
        public void PasswordFieldDisplayedTest()
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            Assert.True(loginPage.IsPasswordFieldDisplayed(), "Password field isn't displayed");
        }

        [Test]
        public void LogInFieldDisplayedTest()
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            Assert.True(loginPage.IsLogInButtonDisplayed(), "Log in field isn't displayed");
        }

        [Test]
        public void LogInTestSuperadmin()
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);

            Assert.IsTrue(allDashboardsPage.IsLaunchesButtonDisplayed(), "Launches button isn't displayed after log in as superadmin");
        }


        [Test]
        public void LogInTestDefault()
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.DefaultUser.UserName, settings.DefaultUser.Password);

            Assert.IsFalse(allDashboardsPage.IsLaunchesButtonDisplayed(), "Launches button isn't displayed after log in as default user");
        }
    }
}