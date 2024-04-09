using Core.Helpers;
using Core.Logger;
using UI.Business.Pages;
namespace ReportPortal
{
    public class AllDashboardsSteps
    {
        private AllDashboardsPage allDashboardsPage = new AllDashboardsPage();
        private ConsoleLogger logger = new ConsoleLogger();
        private AllLaunchesPage allLaunchesPage = new AllLaunchesPage();

        public bool CheckLaunchesButton()
        {
            Waiter.WaitFor(() => allDashboardsPage.LaunchesButton.Enabled);
            logger.Log(new LogEntry(LoggingEventType.Information, "Check Page"));
            return allDashboardsPage.LaunchesButton.Displayed;
        }

        public AllLaunchesPage CLickOnLaunchesButton()
        {
            Waiter.WaitFor(() => allDashboardsPage.LaunchesButton.Enabled);
            logger.Log(new LogEntry(LoggingEventType.Information, "Click on launch button"));
            allDashboardsPage.LaunchesButton.Click();
            return allLaunchesPage;
        }
    }
}