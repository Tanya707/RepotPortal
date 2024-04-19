using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UI.Business.Driver;

namespace Framework.Core.Utilities
{
    public class WebDriverFactory
    {
        private IWebDriver driver;

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void CloseDriverAndFinishHim()
        {
            driver.Quit();
            driver?.Dispose();
            driver = null;
        }
        public IWebDriver InitializeDriver(string type)
        {
            switch (type)
            {
                case "Chrome":
                    {
                        driver = new ChromeDriver();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                        return driver;
                    }

                default:
                    throw new ArgumentException("Incorrect BrowserName");
            }
        }

        public void WindowMaximise()
        {
            driver.Manage().Window.Maximize();
        }

    }
}
