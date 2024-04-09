using Core.Helpers;
using Core.Logger;
using UI.Business.Pages;

namespace UI.Business.Steps
{
    public class AllLaunchesSteps
    {
        private AllDashboardsPage allDashboardsPage = new AllDashboardsPage();
        private ConsoleLogger logger = new ConsoleLogger();
        private AllLaunchesPage allLaunchesPage = new AllLaunchesPage();

        public AllLaunchesPage EnterLaunchName(string launchName)
        {
            Waiter.WaitFor(() => allLaunchesPage.LaunchNameField.Enabled);
            logger.Log(new LogEntry(LoggingEventType.Information, "Enter launch name"));
            allLaunchesPage.EnterLaunchName(launchName);
            return allLaunchesPage;
        }

        public AllLaunchesPage ClickOnFilterByButton()
        {
            Waiter.WaitFor(() => allLaunchesPage.AddFilterButton.Enabled);
            logger.Log(new LogEntry(LoggingEventType.Information, "Click on filter button"));
            allLaunchesPage.AddFilterButton.Click();
            return allLaunchesPage;
        }

        public bool CheckLaunchNames(string name)
        {
            logger.Log(new LogEntry(LoggingEventType.Information, "Check launch name"));
            return allLaunchesPage.launchNames.First().Text.Contains(name);
        }

        public AllLaunchesPage ChooseFilterByTotal()
        {
            Waiter.WaitFor(() => allLaunchesPage.MoreButton.Enabled);
            logger.Log(new LogEntry(LoggingEventType.Information, "Click on More button"));
            allLaunchesPage.MoreButton.Click();
            logger.Log(new LogEntry(LoggingEventType.Information, "Choose Total"));
            Waiter.WaitFor(() => allLaunchesPage.TotalCheckbox.Enabled);
            allLaunchesPage.TotalCheckbox.Click();
            return allLaunchesPage;
        }

        public AllLaunchesPage ChooseFilterByPassed()
        {
            Waiter.WaitFor(() => allLaunchesPage.MoreButton.Enabled);
            logger.Log(new LogEntry(LoggingEventType.Information, "Click on More button"));
            allLaunchesPage.MoreButton.Click();
            logger.Log(new LogEntry(LoggingEventType.Information, "Choose Passe"));
            Waiter.WaitFor(() => allLaunchesPage.PassedCheckbox.Enabled);
            allLaunchesPage.PassedCheckbox.Click();
            return allLaunchesPage;
        }

        public AllLaunchesPage EnterSecondFilterField(string value)
        {
            Waiter.WaitFor(() => allLaunchesPage.SecondFilterField.Enabled);
            logger.Log(new LogEntry(LoggingEventType.Information, "Enter launch name"));
            allLaunchesPage.EnterSecondFilterField(value);
            return allLaunchesPage;
        }

        public AllLaunchesPage SelectEqual()
        {
            logger.Log(new LogEntry(LoggingEventType.Information, "SelectEqual"));
            Waiter.WaitFor(() => allLaunchesPage.Condition.Enabled);
            allLaunchesPage.ClickCondition();
            Waiter.WaitFor(() => allLaunchesPage.EqualCondition.Enabled);
            allLaunchesPage.ClickEqualCondition();
            return allLaunchesPage;
        }

        public bool CheckTotalValues(string total)
        {
            logger.Log(new LogEntry(LoggingEventType.Information, "Check total value"));
            Thread.Sleep(1000);
            return allLaunchesPage.TotalValues.First().Text.Contains(total);
        }

        public bool CheckPassedValues(string passed)
        {
            logger.Log(new LogEntry(LoggingEventType.Information, "Check passed value"));
            Thread.Sleep(1000);
            return allLaunchesPage.PassedValues.First().Text.Contains(passed);
        }
    }
}
