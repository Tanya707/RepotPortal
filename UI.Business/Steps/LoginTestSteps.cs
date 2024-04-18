using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;
namespace ReportPortal
{
    public class LoginTestSteps
    {
        private LoginPage _loginPage;
        private ConsoleLogger _logger = new ConsoleLogger();
        private AllDashboardsPage _allDashboardsPage;

        public LoginTestSteps(IWebDriver driver)
        {
            _allDashboardsPage = new AllDashboardsPage(driver);
            _loginPage = new LoginPage(driver);

        }

        public LoginPage OpenLogInPage(string url)
        {
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, $"Open page {url}"));
            _loginPage.GoToBaseUrl(url);
            return _loginPage;
        }

        public bool IsLogInButtonDisplayed()
        {
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Check button"));
            return _loginPage.LogInButton.Displayed;
        }

        public AllDashboardsPage LogIn(string username, string password)
        {
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Enter credentials"));
            _loginPage.EnterLogin(username);
            _loginPage.EnterPassword(password);
            _loginPage.LogInButton.Click();
            return _allDashboardsPage;
        }
        public bool IsPasswordFieldDisplayed()
        {
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Check Password Field"));
            return _loginPage.PasswordField.Displayed;
        }
        public bool IsLogInFieldDisplayed()
        {
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Log In Field"));
            return _loginPage.LogInField.Displayed;
        }
    }
}