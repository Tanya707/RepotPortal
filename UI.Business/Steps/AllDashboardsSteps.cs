using Core.Helpers;
using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;
namespace ReportPortal
{
    public class AllDashboardsSteps
    {
        private AllDashboardsPage allDashboardsPage;
        private ConsoleLogger logger = new ConsoleLogger();
        private AllLaunchesPage allLaunchesPage;
        private Waiter waiter;

        public AllDashboardsSteps(IWebDriver driver)
        {
            allDashboardsPage = new AllDashboardsPage(driver);
            allLaunchesPage = new AllLaunchesPage(driver);
            waiter = new Waiter(driver);

        }

        public bool CheckLaunchesButton()
        {
            waiter.WaitFor(() => allDashboardsPage.LaunchesButton.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Check Page"));
            return allDashboardsPage.LaunchesButton.Displayed;
        }

        public AllLaunchesPage CLickOnLaunchesButton()
        {
            waiter.WaitFor(() => allDashboardsPage.LaunchesButton.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Click on launch button"));
            allDashboardsPage.LaunchesButton.Click();
            return allLaunchesPage;
        }
    }
}