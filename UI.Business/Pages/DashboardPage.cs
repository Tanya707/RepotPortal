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
            DashboardTables[firstElement].DashboardWidget.DragAndDrop(DashboardTables[secondElement].DashboardWidget.Element);
        }

        public void GetDashboardNameByIndex(int table)
        {
            DashboardTables[table].DashboardNameText();
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
