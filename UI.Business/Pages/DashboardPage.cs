using Core.Driver;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using UI.Business.Components;

namespace UI.Business.Pages
{
    public class DashboardPage : BasePage
    {
        private readonly By _dashboardTable = By.XPath("//*[contains(@class,'react-grid-item widgetsGrid')]");

        public DashboardPage(IWebDriver driver) : base(driver) { }

        public ReadOnlyCollection<DashboardTable> DashboardTables => Driver.FindElements<DashboardTable>(_dashboardTable);

        public void DragAndDropElements(int firstElement, int secondElement)
        {
            Actions.DragAndDrop(DashboardTables[firstElement].DashboardName.Element, DashboardTables[secondElement].DashboardName.Element);
        }
    }
}
