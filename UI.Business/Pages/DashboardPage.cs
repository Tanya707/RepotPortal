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

        public ReadOnlyCollection<DashboardTableComponent> DashboardTables => Driver.FindElements<DashboardTableComponent>(_dashboardTable);

        public DashboardPage DragAndDropElements(int firstElement, int secondElement)
        {
            DashboardTables[firstElement].DashboardWidget.DragAndDrop(DashboardTables[secondElement].DashboardWidget.Element);
            return this;
        }

        public string GetDashboardNameByIndex(int table)
        {
            var tableByIndex = DashboardTables[table];
            return tableByIndex.DashboardNameText();
        }

        public void ResizeFirstTable(int xOffset, int yOffset)
        {
            DashboardTables.First().ResizeTable(xOffset, yOffset);
        }

        public (int height, int width) GetHeightAndWidthOfFirstTable()
        {
            var height = DashboardTables.First().FrameOfTable.Height();
            var width = DashboardTables.First().FrameOfTable.Width();
            return (height, width);
        }
    }
}
