using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;
using UI.Business.Steps;
namespace ReportPortal
{
    public class LoginTestSteps:BaseSteps
    {
        public LoginTestSteps(IWebDriver driver) : base(driver) { }

        public LoginPage OpenLogInPage(string url)
        {
            LogInfoExtensions.Log(_logger, $"Open page {url}");
            _loginPage.GoToBaseUrl(url);
            return _loginPage;
        }

        public bool IsLogInButtonDisplayed()
        {
            LogInfoExtensions.Log(_logger, "Check button");
            return _loginPage.LogInButton.Displayed;
        }

        public AllDashboardsPage LogIn(string username, string password)
        {
            LogInfoExtensions.Log(_logger, "Enter credentials");
            _loginPage.EnterLogin(username);
            _loginPage.EnterPassword(password);
            _loginPage.LogInButton.Click();
            return _allDashboardsPage;
        }
        public bool IsPasswordFieldDisplayed()
        {
            LogInfoExtensions.Log(_logger, "Check Password Field");
            return _loginPage.PasswordField.Displayed;
        }
        public bool IsLogInFieldDisplayed()
        {
            LogInfoExtensions.Log(_logger, "Log In Field");
            return _loginPage.LogInField.Displayed;
        }
    }
}