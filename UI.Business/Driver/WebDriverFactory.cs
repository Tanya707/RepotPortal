﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject.Enums;

namespace Framework.Core.Utilities
{
    public class WebDriverFactory
    {
        private static IWebDriver driver;

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
        public IWebDriver InitializeDriver(Enum type)
        {
            switch (type)
            {
                case BrowserList.Chrome:
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

        public void FinishHim()
        {
            driver?.Dispose();
        }

    }
}
