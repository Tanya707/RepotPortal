using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;

namespace UI.Business.Steps
{
    public class LoginTestSteps:BaseSteps
    {
        public LoginTestSteps(IWebDriver driver) : base(driver) { }

        public LoginPage OpenLogInPage(string url)
        {
            LogInfoExtensions.LogInfo(_logger, $"Open page {url}");
            _loginPage.GoToBaseUrl(url);
            return _loginPage;
        }

        public bool IsLogInButtonDisplayed()
        {
            LogInfoExtensions.LogInfo(_logger, "Check button");
            return _loginPage.LogInButton.Displayed();
        }

        public MenuPage LogIn(string username, string password)
        {
            LogInfoExtensions.LogInfo(_logger, "Enter credentials");
            _loginPage.EnterLogin(username);
            _loginPage.EnterPassword(password);
            _loginPage.LogInButton.Click();
            return _menuPage;
        }
        public bool IsPasswordFieldDisplayed()
        {
            LogInfoExtensions.LogInfo(_logger, "Check Password Field");
            return _loginPage.PasswordField.Displayed();
        }
        public bool IsLogInFieldDisplayed()
        {
            LogInfoExtensions.LogInfo(_logger, "Log In Field");
            return _loginPage.LogInField.Displayed();
        }
    }
}