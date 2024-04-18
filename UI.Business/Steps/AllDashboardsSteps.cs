using Core.Helpers;
using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;
namespace ReportPortal
{
    public class AllDashboardsSteps
    {
        private AllDashboardsPage _allDashboardsPage;
        private ConsoleLogger _logger = new ConsoleLogger();
        private AllLaunchesPage _allLaunchesPage;
        private Waiter _waiter;

        public AllDashboardsSteps(IWebDriver driver)
        {
            _allDashboardsPage = new AllDashboardsPage(driver);
            _allLaunchesPage = new AllLaunchesPage(driver);
            _waiter = new Waiter(driver);

        }

        public bool IsLaunchesButtonDisplayed()
        {
            _waiter.WaitFor(() => _allDashboardsPage.LaunchesButton.Enabled);
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Check Page"));
            return _allDashboardsPage.LaunchesButton.Displayed;
        }

        public AllLaunchesPage CLickOnLaunchesButton()
        {
            _waiter.WaitFor(() => _allDashboardsPage.LaunchesButton.Enabled);
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Click on launch button"));
            _allDashboardsPage.LaunchesButton.Click();
            return _allLaunchesPage;
        }
    }
}