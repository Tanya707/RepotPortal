using OpenQA.Selenium;

namespace UI.Business.Pages
{
    public class AllDashboardsPage : BasePage
    {
        private readonly By launchesButton = By.XPath("(//a[contains(@class,'sidebarButton__nav-link')])[2]");

        public AllDashboardsPage(IWebDriver driver) : base(driver) { }

        public IWebElement LaunchesButton => Driver.FindElement(launchesButton);
    }
}
