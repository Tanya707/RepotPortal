using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject.Enums;

namespace Framework.Core.Utilities
{
    public static class WebDriverFactory
    {
        private static IWebDriver driver;

        public static IWebDriver GetDriver()
        {
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
        public static IWebDriver InitializeDriver(Enum type)
        {
            switch (type)
            {
                case BrowserList.Chrome:
                    {
                        driver = new ChromeDriver();
                        return driver;
                    }

                default:
                    throw new ArgumentException("Incorrect BrowserName");
            }
        }

        public static void WindowMaximise()
        {
            driver.Manage().Window.Maximize();
        }

        public static void FinishHim()
        {
            driver?.Dispose();
        }

    }
}
