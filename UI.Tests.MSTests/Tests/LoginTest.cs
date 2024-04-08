using Core.Helpers;
using Core.Logger;
using Core.Models;
using Framework.Core.Pages;
using Framework.Core.Tests;
using Framework.Core.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using UI.Core._Business.Pages;
namespace ReportPortal
{
    [TestClass]
    public class LoginTest : BaseTest
    {

        [TestMethod]
        public void LogInButtonTest()
        {
            var settings = SettingHelper.LoadFromAppSettings();
            var logger = new ConsoleLogger();
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "1. Open page"));
            LoginPage loginPage = new LoginPage();
            loginPage.GoToBaseUrl(settings.ReportPortalUrl.LocalBaseUrl);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "2. Check button"));
            var logInButton = loginPage.LogInButton.Displayed;
            Assert.IsTrue(logInButton);
        }

        [TestMethod]
        public void LogInTestSuperadmin()
        {
            var logger = new ConsoleLogger();
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "1. Open page"));
            LoginPage loginPage = new LoginPage();
            loginPage.GoToBaseUrl(settings.ReportPortalUrl.LocalBaseUrl);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "2. Log in"));
            loginPage.EnterLogin(settings.SuperadminUser.UserName);
            loginPage.EnterPassword(settings.SuperadminUser.Password);
            loginPage.LogInButton.Click();
            AllDashboardsPage allDashboardsPage = new AllDashboardsPage();
            Waiter.WaitFor(() => allDashboardsPage.LaunchesButton.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "3. Check Page"));
            Assert.IsTrue(allDashboardsPage.LaunchesButton.Displayed);
        }

        [TestMethod]
        public void LogInTestDefaultUser()
        {
            var logger = new ConsoleLogger();
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "1. Open page"));
            LoginPage loginPage = new LoginPage();
            loginPage.GoToBaseUrl(settings.ReportPortalUrl.LocalBaseUrl);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "2. Log in"));
            loginPage.EnterLogin(settings.DefaultUser.UserName);
            loginPage.EnterPassword(settings.DefaultUser.Password);
            loginPage.LogInButton.Click();
            AllDashboardsPage allDashboardsPage = new AllDashboardsPage();
            Waiter.WaitFor(() => allDashboardsPage.LaunchesButton.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "3. Check Page"));
            Assert.IsTrue(allDashboardsPage.LaunchesButton.Displayed);
        }
    }
}