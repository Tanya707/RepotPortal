using Core.Helpers;
using Core.Logger;
using Framework.Core.Pages;
using Framework.Core.Tests;
using Framework.Core.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using UI.Core._Business.Pages;
namespace ReportPortal
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LoginTest : BaseTest
    {
        [Test]
        public void LogInLogInButtonDisplayedTest()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            Assert.IsTrue(loginPage.CheckLogInButton());
        }

        [Test]
        public void LogInPasswordFieldDisplayedTest()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            Assert.True(loginPage.CheckPasswordField());
        }

        [Test]
        public void LogInLogInFieldDisplayedTest()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            Assert.True(loginPage.CheckLogInButton());
        }

        [Test]
        public void LogInTestSuperadmin()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps();
            Assert.IsTrue(allDashboardsPage.CheckLaunchesButton());
        }


        [Test]
        public void LogInTestDefault()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.DefaultUser.UserName, settings.DefaultUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps();
            Assert.IsFalse(allDashboardsPage.CheckLaunchesButton());
        }
    }
}