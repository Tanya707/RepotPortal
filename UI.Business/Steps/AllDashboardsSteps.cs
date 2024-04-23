using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;
using UI.Business.Steps;
namespace ReportPortal
{
    public class AllDashboardsSteps:BaseSteps
    {
        public AllDashboardsSteps(IWebDriver driver) : base(driver) { }

        public bool IsLaunchesButtonDisplayed()
        {
            _waiter.WaitFor(() => _allDashboardsPage.LaunchesButton.Enabled);
            return _allDashboardsPage.LaunchesButton.Displayed;
        }

        public AllLaunchesPage CLickOnLaunchesButton()
        {
            _waiter.WaitFor(() => _allDashboardsPage.LaunchesButton.Enabled);
            LogInfoExtensions.LogInfo(_logger, "Click on launch button");
            _allDashboardsPage.LaunchesButton.Click();
            return _allLaunchesPage;
        }
    }
}