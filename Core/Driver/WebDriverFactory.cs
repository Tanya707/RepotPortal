using Core.Helpers;
using Core.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Core.Utilities
{
    public class WebDriverFactory
    {
        private IWebDriver driver;
        protected static ConfigSettings configs = SettingHelper.LoadFromConfigSettings();

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
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(configs.Timeout);
                        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(configs.PageLoadTimeout);
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
