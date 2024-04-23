using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Enums;

namespace Framework.Core.Utilities
{
    public class Browser
    {
        private static IWebDriver driver;

        public static IWebDriver GetBrowser()
        {
            return driver ??= WebDriverFactory.InitializeDriver(BrowserList.Chrome);
        }

        public static void WindowMaximise()
        {
            GetBrowser().Manage().Window.Maximize();
        }

        public static void NavigateTo(string url)
        {
            GetBrowser().Navigate().GoToUrl(url);
        }

        public static void Quit()
        {
            GetBrowser().Close();
        }

    }
}
