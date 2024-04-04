using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject.Enums;

namespace Framework.Core.Utilities
{
    public static class WebDriverFactory
    {
        private static IWebDriver driver;
        public static IWebDriver InitializeDriver(Enum type)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserList.Chrome:
                    {
                        driver = new ChromeDriver();
                        break;
                    }

                default:
                    throw new ArgumentException("Incorrect BrowserName");
            }
                return driver;
        }

        public static IWebDriver GetDriver()
        {
            return driver;
        }
    }
}
