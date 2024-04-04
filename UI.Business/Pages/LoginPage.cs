using OpenQA.Selenium;
using UI.Core._Business.Pages;

namespace Framework.Core.Pages
{
    public class LoginPage
    {

        protected IWebDriver driver;
        private readonly By logInWithEpamButton = By.XPath("//button[@type='button']");
        private readonly By logInButton = By.XPath("//button[@type='submit']");
        private readonly By logInField = By.XPath("//input[@type='text']");
        private readonly By passwordField = By.XPath("//input[@type='password']");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement LogInWithEpam => driver.FindElement(logInWithEpamButton);
        public IWebElement LogInButton => driver.FindElement(logInButton);
        public IWebElement LogInField => driver.FindElement(logInField);
        public IWebElement PasswordField => driver.FindElement(passwordField);

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
