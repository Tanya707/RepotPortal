using OpenQA.Selenium;

namespace UI.Business.Pages
{
    public class LoginPage:BasePage
    {
        private readonly By logInWithEpamButton = By.XPath("//button[@type='button']");
        private readonly By logInButton = By.XPath("//button[@type='submit']");
        private readonly By logInField = By.XPath("//input[@type='text']");
        private readonly By passwordField = By.XPath("//input[@type='password']");

        public IWebElement LogInWithEpam => Driver.FindElement(logInWithEpamButton);
        public IWebElement LogInButton => Driver.FindElement(logInButton);
        public IWebElement LogInField => Driver.FindElement(logInField);
        public IWebElement PasswordField => Driver.FindElement(passwordField);

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
