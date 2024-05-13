using Core.Driver;
using Core.Elements;
using OpenQA.Selenium;

namespace UI.Business.Pages
{
    public class LoginPage:BasePage
    {
        private readonly By _logInWithEpamButton = By.XPath("//*[@type='button']");
        private readonly By _logInButton = By.XPath("//*[@type='submit']");
        private readonly By _logInField = By.XPath("//*[@type='text']");
        private readonly By _passwordField = By.XPath("//*[@type='password']");

        public Button LogInWithEpam => Driver.FindElement<Button>(_logInWithEpamButton);
        public Button LogInButton => Driver.FindElement<Button>(_logInButton);
        public TextField LogInField => Driver.FindElement<TextField>(_logInField);
        public TextField PasswordField => Driver.FindElement<TextField>(_passwordField);

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void GoToBaseUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }


        public void EnterLogin(string login)
        {
            LogInField.EnterText(login);
        }

        public void EnterPassword(string password)
        {
            PasswordField.EnterText(password);
        }

    }
}
