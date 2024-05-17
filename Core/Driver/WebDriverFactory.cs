using Core.Helpers;
using Core.HttpClient;
using Core.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core.Driver
{
    public class WebDriverFactory
    {
        private IWebDriver _driver;
        protected static ConfigSettings configs = SettingHelper.LoadFromConfigSettings();

        public IWebDriver GetDriver()
        {
            return _driver;
        }

        public void CloseDriverAndFinishHim()
        {
            _driver.Quit();
            _driver?.Dispose();
            _driver = null;
        }
        public IWebDriver InitializeDriver(string type)
        {
            Enum.TryParse(type, out BrowserList browser);
            switch (browser)
            {
                case BrowserList.Chrome:
                    {
                        _driver = new ChromeDriver();
                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(configs.Timeout);
                        _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(configs.PageLoadTimeout);
                        return _driver;
                    }

                default:
                    throw new ArgumentException("Incorrect BrowserName");
            }
        }

        public void WindowMaximize()
        {
            _driver.Manage().Window.Maximize();
        }

    }
}
