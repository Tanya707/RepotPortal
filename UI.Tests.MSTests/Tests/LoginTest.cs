
[assembly: Parallelize(Workers = 5, Scope = ExecutionScope.MethodLevel)]

namespace UI.Tests.MSTests.Tests
{
    [TestClass]
    public class LoginTest : BaseTestMSTest
    {
        [TestMethod]
        public void LogInButtonTest()
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            Assert.IsTrue(loginPage.IsLogInButtonDisplayed(), "Log in button isn't displayed");
        }

        [TestMethod]
        public void LogInTestSuperadmin()
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);

            Assert.IsTrue(menuPage.IsLaunchesButtonDisplayed(), "Launches button isn't dispalyed after log in as superadmin");
        }

        [TestMethod]
        public void LogInTestDefaultUser()
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.DefaultUser.UserName, settings.DefaultUser.Password);

            Assert.IsFalse(menuPage.IsLaunchesButtonDisplayed(), "Launches button isn't dispalyed after log in as default user");
        }
    }
}