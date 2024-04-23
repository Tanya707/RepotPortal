using OpenQA.Selenium;

namespace Framework.Core.Pages
{
    public class LoginPage
    {

        protected IWebDriver driver;
        private readonly By logInWithEpam = By.XPath("//button[contains(@class, 'bigButton__big-button')]");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement LogInWithEpam => driver.FindElement(logInWithEpam);

        public void ClickLoginWithEpam()
        {
            
        }


    }
}
