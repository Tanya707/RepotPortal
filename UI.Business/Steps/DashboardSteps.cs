using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;

namespace UI.Business.Steps
{
    public class DashboardSteps : BaseSteps
    {
        public DashboardSteps(IWebDriver driver) : base(driver) { }

        public DashboardPage ChangePlacesOfTwoTables(int firstTable, int secondTable)
        {
            _waiter.WaitFor(() => _dashboardPage.DashboardTables.First().DashboardName.Displayed());
            LogInfoExtensions.LogInfo(_logger, "Change places of two tables");
            _dashboardPage.DragAndDropElements(firstTable, secondTable);
            return _dashboardPage;
        }

        public string GetDashboardNameByIndex(int table)
        {
            _waiter.WaitFor(() => _dashboardPage.DashboardTables.First().DashboardName.Displayed());
            LogInfoExtensions.LogInfo(_logger, $"Get Dashboard Name By Index {table}");
            return _dashboardPage.GetDashboardNameByIndex(table);
        }

        public DashboardPage ResizeFirstTable(int xOffset, int yOffset)
        {
            _waiter.WaitFor(() => _dashboardPage.DashboardTables.First().DashboardName.Displayed());
            LogInfoExtensions.LogInfo(_logger, "Resize first table");
            _dashboardPage.ResizeFirstTable(xOffset, yOffset);
            return _dashboardPage;
        }

        public (int height, int width) GetHeightAndWidthOfFirstTable()
        {
            _waiter.WaitFor(() => _dashboardPage.DashboardTables.First().DashboardName.Displayed());
            LogInfoExtensions.LogInfo(_logger, "Resize first table");
            var(height,width) = _dashboardPage.GetHeightAndWidthOfFirstTable();
            return (height, width);
        }
    }
}
