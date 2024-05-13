using Core.Driver;
using Core.Elements;
using OpenQA.Selenium;

namespace UI.Business.Pages
{
    public class AllDashboardsPage : BasePage
    {
        private readonly By _launchesButton = By.XPath("//*[contains(@href,'/launches')]");

        public AllDashboardsPage(IWebDriver driver) : base(driver) { }

        public Button LaunchesButton => Driver.FindElement<Button>(_launchesButton);
    }
}
