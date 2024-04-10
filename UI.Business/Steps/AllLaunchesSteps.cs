using Core.Helpers;
using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;

namespace UI.Business.Steps
{
    public class AllLaunchesSteps
    {
        private AllDashboardsPage allDashboardsPage;
        private ConsoleLogger logger = new ConsoleLogger();
        private AllLaunchesPage allLaunchesPage;
        private Waiter waiter;

        public AllLaunchesSteps(IWebDriver driver) {

            allDashboardsPage = new AllDashboardsPage(driver);
            allLaunchesPage = new AllLaunchesPage(driver);
            waiter = new Waiter(driver);

        }

        public AllLaunchesPage EnterLaunchName(string launchName)
        {
            waiter.WaitFor(() => allLaunchesPage.LaunchNameField.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Enter launch name"));
            allLaunchesPage.EnterLaunchName(launchName);
            return allLaunchesPage;
        }

        public AllLaunchesPage ClickOnFilterByButton()
        {
            waiter.WaitFor(() => allLaunchesPage.AddFilterButton.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Click on filter button"));
            allLaunchesPage.AddFilterButton.Click();
            return allLaunchesPage;
        }

        public bool CheckLaunchNames(string name)
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Check launch name"));
            return allLaunchesPage.launchNames.First().Text.Contains(name);
        }

        public AllLaunchesPage ChooseFilterByTotal()
        {
            waiter.WaitFor(() => allLaunchesPage.MoreButton.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Click on More button"));
            allLaunchesPage.MoreButton.Click();
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Choose Total"));
            waiter.WaitFor(() => allLaunchesPage.TotalCheckbox.Enabled);
            allLaunchesPage.TotalCheckbox.Click();
            return allLaunchesPage;
        }

        public AllLaunchesPage ChooseFilterByPassed()
        {
            waiter.WaitFor(() => allLaunchesPage.MoreButton.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Click on More button"));
            allLaunchesPage.MoreButton.Click();
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Choose Passe"));
            waiter.WaitFor(() => allLaunchesPage.PassedCheckbox.Enabled);
            allLaunchesPage.PassedCheckbox.Click();
            return allLaunchesPage;
        }

        public AllLaunchesPage EnterSecondFilterField(string value)
        {
            waiter.WaitFor(() => allLaunchesPage.SecondFilterField.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Enter launch name"));
            allLaunchesPage.EnterSecondFilterField(value);
            return allLaunchesPage;
        }

        public AllLaunchesPage SelectEqual()
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "SelectEqual"));
            waiter.WaitFor(() => allLaunchesPage.Condition.Enabled);
            allLaunchesPage.ClickCondition();
            waiter.WaitFor(() => allLaunchesPage.EqualCondition.Enabled);
            allLaunchesPage.ClickEqualCondition();
            return allLaunchesPage;
        }

        public bool CheckTotalValues(string total)
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Check total value"));
            Thread.Sleep(1000);
            return allLaunchesPage.TotalValues.First().Text.Contains(total);
        }

        public bool CheckPassedValues(string passed)
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Check passed value"));
            Thread.Sleep(1000);
            return allLaunchesPage.PassedValues.First().Text.Contains(passed);
        }
    }
}
