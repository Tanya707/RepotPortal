using Core.Logger;
using Core.Models;
using Framework.Core.Contexts;
using Framework.Core.Pages;
using Framework.Core.Utilities;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using Reqnroll;
using UI.Core._Business.Pages;
namespace ReportPortal
{
    public class LoginTestSteps
    {
        private LoginPage loginPage= new LoginPage();
        private ConsoleLogger logger = new ConsoleLogger();
        private AllDashboardsPage allDashboardsPage = new AllDashboardsPage();


        public LoginPage OpenLogInPage(string url)
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "1. Open page"));
            loginPage.GoToBaseUrl(url);
            return loginPage;
        }

        public bool CheckLogInButton()
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "2. Check button"));
            return loginPage.LogInButton.Displayed;
        }

        public AllDashboardsPage LogIn(string username, string password)
        {
            loginPage.EnterLogin(username);
            loginPage.EnterPassword(password);
            loginPage.LogInButton.Click();
            return allDashboardsPage;
        }
        public bool CheckPasswordField()
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "2. Check button"));
            return loginPage.PasswordField.Displayed;
        }
        public bool CheckLogInField()
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "2. Check button"));
            return loginPage.LogInField.Displayed;
        }
    }
}