using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Core._Business.Pages
{
    public class AllDashboardsPage
    {
        protected IWebDriver driver;
        private readonly By launchesButton = By.XPath("//a[contains(@href,'launches')]");
        private readonly By logInButton = By.XPath("//button[@type='submit']");
        private readonly By logInField = By.XPath("//input[@type='text']");
        private readonly By passwordField = By.XPath("//input[@type='password']");

        public AllDashboardsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement LaunchesButton => driver.FindElement(launchesButton);
    }
}
