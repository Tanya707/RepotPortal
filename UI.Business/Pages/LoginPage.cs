using OpenQA.Selenium;

namespace UI.Business.Pages
{
    public class LoginPage:BasePage
    {
        private readonly By _logInWithEpamButton = By.XPath("//*[@type='button']");
        private readonly By _logInButton = By.XPath("//*[@type='submit']");
        private readonly By _logInField = By.XPath("//*[@type='text']");
        private readonly By _passwordField = By.XPath("//*[@type='password']");

        public IWebElement LogInWithEpam => Driver.FindElement(_logInWithEpamButton);
        public IWebElement LogInButton => Driver.FindElement(_logInButton);
        public IWebElement LogInField => Driver.FindElement(_logInField);
        public IWebElement PasswordField => Driver.FindElement(_passwordField);

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void GoToBaseUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }


        public void EnterLogin(string login)
        {
            LogInField.Clear();
            LogInField.SendKeys(login);
        }

        public void EnterPassword(string password)
        {
            PasswordField.Clear();
            PasswordField.SendKeys(password);
        }

    }
}
