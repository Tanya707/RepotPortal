using Core.Driver;
using Core.Elements;
using OpenQA.Selenium;

namespace UI.Business.Pages
{
    public class MenuPage : BasePage
    {
        private readonly By _launchesButton = By.XPath("//*[contains(@href,'/launches')]");
        private readonly By _dashboardButton = By.XPath("//*[contains(@class,'sidebarButton__active')]");

        public MenuPage(IWebDriver driver) : base(driver) { }

        public Button LaunchesButton => Driver.FindElement<Button>(_launchesButton);
        public Button DashboardButton => Driver.FindElement<Button>(_dashboardButton);

        public void ClickOnLaunchButtonWithJs()
        {
            LaunchesButton.ClickJS();
        }
    }
}
