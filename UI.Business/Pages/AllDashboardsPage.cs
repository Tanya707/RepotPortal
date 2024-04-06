using Framework.Core.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Business.Pages;

namespace UI.Core._Business.Pages
{
    public class AllDashboardsPage : BasePage
    {
        private IWebDriver Driver = WebDriverFactory.GetDriver();
        private readonly By launchesButton = By.XPath("//a[contains(@href,'launches')]");
        private readonly By logInButton = By.XPath("//button[@type='submit']");
        private readonly By logInField = By.XPath("//input[@type='text']");
        private readonly By passwordField = By.XPath("//input[@type='password']");

        public IWebElement LaunchesButton => Driver.FindElement(launchesButton);
    }
}
