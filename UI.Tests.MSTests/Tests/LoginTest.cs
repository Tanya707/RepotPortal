using Core.Helpers;
using Core.Logger;
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
        private LoginPage loginPage;

        [TestMethod]
        public void LogInButtonTest()
        {
            var logger = new ConsoleLogger();
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "1. Open page"));
            OpenMainPage("http://localhost:8080");
            loginPage = new LoginPage(Browser.GetBrowser());
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "2. Check button"));
            var logInButton = loginPage.LogInButton.Displayed;
            Assert.IsTrue(logInButton);
        }

        [TestMethod]
        [DataRow("superadmin", "erebus")]
        [DataRow("default", "1q2w3e")]
        public void LogInTest(string login, string password)
        {
            var logger = new ConsoleLogger();
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "1. Open page"));
            OpenMainPage("http://localhost:8080");
            loginPage = new LoginPage(Browser.GetBrowser());
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "2. Log in"));
            loginPage.EnterLogin(login);
            loginPage.EnterPassword(password);
            loginPage.LogInButton.Click();
            AllDashboardsPage allDashboardsPage = new AllDashboardsPage(Browser.GetBrowser());
            Waiter.WaitFor(() => allDashboardsPage.LaunchesButton.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "3. Check Page"));
            Assert.IsTrue(allDashboardsPage.LaunchesButton.Displayed);
        }
    }
}