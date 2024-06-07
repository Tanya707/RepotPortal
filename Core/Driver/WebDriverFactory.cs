using Core.Helpers;
using Core.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

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
            Enum.TryParse(type, out BrowserTypes browser);
            switch (browser)
            {
                case BrowserTypes.Chrome:
                    {

                        var service = ChromeDriverService.CreateDefaultService(new DriverManager().SetUpDriver(new ChromeConfig()));
                        var options = new ChromeOptions();
                        options.AddArguments("--disable-web-security", "start-maximized", "--disable-extensions");
                        options.AddUserProfilePreference("download.prompt_for_download", false);
                        options.AddUserProfilePreference("disable-popup-blocking", true);
                        options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
                        options.AddUserProfilePreference("download.directory_upgrade", true);
                        options.AddUserProfilePreference("safebrowsing.enabled", false);

                        options.AddArgument("--safebrowsing-disable-download-protection");
                        options.AddArgument("--safebrowsing-disable-extension-blacklist");
                        options.AddArgument("--safebrowsing-disable-auto-update");
                        options.AddArgument("--safebrowsing-manual-download-blacklist");
                        options.AddArgument("--allow-unchecked-dangerous-downloads");
                        options.AddArgument("--ignore-certificate-errors");
                        options.AddArgument("--allow-running-insecure-content");
                        options.AddArgument("--allow-insecure-localhost");
                        options.AddArgument("--disable-popup-blocking");
                        _driver = new ChromeDriver(service, options);
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
