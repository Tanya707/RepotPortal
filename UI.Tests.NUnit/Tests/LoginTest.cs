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
        private LoginPage loginPage;

        [Test]
        public void LogInLogInButtonDisplayedTest()
        {
            var logger = new ConsoleLogger();
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "1. Open page"));
            OpenMainPage("http://localhost:8080");
            loginPage = new LoginPage(Browser.GetBrowser());
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "2. Check button"));
            var logInButton = loginPage.LogInButton.Displayed;
            Assert.True(logInButton);
        }

        [Test]
        public void LogInPasswordFieldDisplayedTest()
        {
            var logger = new ConsoleLogger();
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "1. Open page"));
            OpenMainPage("http://localhost:8080");
            loginPage = new LoginPage(Browser.GetBrowser());
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "2. Check field"));
            var passwordField = loginPage.PasswordField.Displayed;
            Assert.True(passwordField);
        }

        [Test]
        public void LogInLogInFieldDisplayedTest()
        {
            var logger = new ConsoleLogger();
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "1. Open page"));
            OpenMainPage("http://localhost:8080");
            loginPage = new LoginPage(Browser.GetBrowser());
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "2. Check field"));
            var logInField = loginPage.LogInField.Displayed;
            Assert.True(logInField);
        }

        [TestCase("superadmin", "erebus")]
        [TestCase("default", "1q2w3e")]
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
            Assert.True(allDashboardsPage.LaunchesButton.Displayed);
        }
    }
}