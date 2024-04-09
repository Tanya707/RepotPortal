using Core.Helpers;
using Core.Logger;
using Core.Models;
using Framework.Core.Pages;
using Framework.Core.Tests;
using Framework.Core.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using UI.Business.Steps;
using UI.Core._Business.Pages;
namespace ReportPortal
{
    [TestClass]
    public class LoginTest : BaseTest
    {

        [TestMethod]
        public void LogInButtonTest()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            Assert.IsTrue(loginPage.CheckLogInButton());
        }

        [TestMethod]
        public void LogInTestSuperadmin()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps();
            Assert.IsTrue(allDashboardsPage.CheckLaunchesButton());
        }

        [TestMethod]
        public void LogInTestDefaultUser()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.DefaultUser.UserName, settings.DefaultUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps();
            Assert.IsFalse(allDashboardsPage.CheckLaunchesButton());
        }

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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