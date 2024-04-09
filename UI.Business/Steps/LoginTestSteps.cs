using Core.Logger;
using Framework.Core.Pages;
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
            logger.Log(new LogEntry(LoggingEventType.Information, "Open page"));
            loginPage.GoToBaseUrl(url);
            return loginPage;
        }

        public bool CheckLogInButton()
        {
            logger.Log(new LogEntry(LoggingEventType.Information, "Check button"));
            return loginPage.LogInButton.Displayed;
        }

        public AllDashboardsPage LogIn(string username, string password)
        {
            logger.Log(new LogEntry(LoggingEventType.Information, "Enter credentials"));
            loginPage.EnterLogin(username);
            loginPage.EnterPassword(password);
            loginPage.LogInButton.Click();
            return allDashboardsPage;
        }
        public bool CheckPasswordField()
        {
            logger.Log(new LogEntry(LoggingEventType.Information, "Check Password Field"));
            return loginPage.PasswordField.Displayed;
        }
        public bool CheckLogInField()
        {
            logger.Log(new LogEntry(LoggingEventType.Information, "Log In Field"));
            return loginPage.LogInField.Displayed;
        }
    }
}