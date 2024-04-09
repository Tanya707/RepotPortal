using Core.Helpers;
using Core.Logger;
using Framework.Core.Pages;
using Framework.Core.Tests;
using Framework.Core.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using UI.Business.Steps;
using UI.Core._Business.Pages;
namespace ReportPortal
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LoginTest : BaseTest
    {
        [Test]
        public void LogInButtonDisplayedTest()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            Assert.IsTrue(loginPage.CheckLogInButton());
        }

        [Test]
        public void PasswordFieldDisplayedTest()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            Assert.True(loginPage.CheckPasswordField());
        }

        [Test]
        public void LogInFieldDisplayedTest()
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

        [Test]
        public void FilterByLaunchName()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps();
            allDashboardsPage.CLickOnLaunchesButton();
            AllLaunchesSteps allLaunchesPage = new AllLaunchesSteps();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.EnterLaunchName("Api");
            Assert.IsTrue(allLaunchesPage.CheckLaunchNames("Api"));
        }

        [Test]
        public void FilterByTotal()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps();
            allDashboardsPage.CLickOnLaunchesButton();
            AllLaunchesSteps allLaunchesPage = new AllLaunchesSteps();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByTotal();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField("10");
            Assert.IsTrue(allLaunchesPage.CheckTotalValues("10"));
        }

        [Test]
        public void FilterByPassed()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps();
            allDashboardsPage.CLickOnLaunchesButton();
            AllLaunchesSteps allLaunchesPage = new AllLaunchesSteps();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByPassed();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField("10");
            Assert.IsTrue(allLaunchesPage.CheckPassedValues("10"));
        }
    }
}