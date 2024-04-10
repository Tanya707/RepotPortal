using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;
namespace ReportPortal
{
    public class LoginTestSteps
    {
        private LoginPage loginPage;
        private ConsoleLogger logger = new ConsoleLogger();
        private AllDashboardsPage allDashboardsPage;

        public LoginTestSteps(IWebDriver driver)
        {
            allDashboardsPage = new AllDashboardsPage(driver);
            loginPage = new LoginPage(driver);

        }

        public LoginPage OpenLogInPage(string url)
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Open page"));
            loginPage.GoToBaseUrl(url);
            return loginPage;
        }

        public bool CheckLogInButton()
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Check button"));
            return loginPage.LogInButton.Displayed;
        }

        public AllDashboardsPage LogIn(string username, string password)
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Enter credentials"));
            loginPage.EnterLogin(username);
            loginPage.EnterPassword(password);
            loginPage.LogInButton.Click();
            return allDashboardsPage;
        }
        public bool CheckPasswordField()
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Check Password Field"));
            return loginPage.PasswordField.Displayed;
        }
        public bool CheckLogInField()
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Log In Field"));
            return loginPage.LogInField.Displayed;
        }
    }
}