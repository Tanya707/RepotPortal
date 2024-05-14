using Core.Elements;
using OpenQA.Selenium;
using Core.Driver;

namespace UI.Business.Components
{
    public class DashboardTable:BaseComponent
    {
        private readonly By _dashboardName = By.XPath("//*[contains(@class,'widgetHeader__widget-name-block')]");

        public DashboardTable(IWebDriver driver) : base(driver)
        {
        }

        public BasicElement DashboardName => Driver.FindElement<BasicElement>(_dashboardName);
        public bool DashboardNameDisplayed() => DashboardName.Displayed();
    }
}
