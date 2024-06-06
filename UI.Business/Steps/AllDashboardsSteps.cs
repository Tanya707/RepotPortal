using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;

namespace UI.Business.Steps
{
    public class AllDashboardsSteps : BaseSteps
    {
        public AllDashboardsSteps(IWebDriver driver) : base(driver) { }

        public DashboardPage ClickOnDashboardButton()
        {
            _waiter.WaitFor(() => _allDashboardsPage.DashboardButton.Enabled());
            LogInfoExtensions.LogInfo(_logger, "Click on dashboard Button");
            _allDashboardsPage.ClickOnDashboardButton();
            return _dashboardPage;
        }
    }
}
