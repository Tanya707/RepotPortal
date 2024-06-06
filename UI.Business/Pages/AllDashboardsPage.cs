using Core.Driver;
using OpenQA.Selenium;
using UI.Business.CustomElements;

namespace UI.Business.Pages
{
    public class AllDashboardsPage : BasePage
    {
        private readonly By _dashboardButton = By.XPath("//*[contains(@class,'dashboardTable__name')]");


        public AllDashboardsPage(IWebDriver driver) : base(driver) { }

        public Button DashboardButton => Driver.FindElement<Button>(_dashboardButton) ;

        public void ClickOnDashboardButton() => DashboardButton.Click();
    }
}
