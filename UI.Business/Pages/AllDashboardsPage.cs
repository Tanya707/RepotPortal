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
        private readonly By launchesButton = By.XPath("(//a[contains(@class,'sidebarButton__nav-link')])[2]");

        public IWebElement LaunchesButton => Driver.FindElement(launchesButton);
    }
}
