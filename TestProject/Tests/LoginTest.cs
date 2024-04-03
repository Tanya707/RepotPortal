using Core.Logger;
using Framework.Core.Pages;
using Framework.Core.Tests;
using Framework.Core.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
namespace ReportPortal
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        private LoginPage loginPage;

        [Test]
        public void LogInTest()
        {
            var logger = new ConsoleLogger();
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "1. Open page"));
            OpenMainPage("https://rp.epam.com");
            loginPage = new LoginPage(Browser.GetBrowser());
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "2. Check button"));
            var logInWithEpam = loginPage.LogInWithEpam.Displayed;
            Assert.True(logInWithEpam);
        }
    }
}