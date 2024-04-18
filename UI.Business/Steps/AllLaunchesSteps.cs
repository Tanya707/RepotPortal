using Core.Helpers;
using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;

namespace UI.Business.Steps
{
    public class AllLaunchesSteps
    {
        private AllDashboardsPage _allDashboardsPage;
        private ConsoleLogger _logger = new ConsoleLogger();
        private AllLaunchesPage _allLaunchesPage;
        private Waiter _waiter;

        public AllLaunchesSteps(IWebDriver driver) {

            _allDashboardsPage = new AllDashboardsPage(driver);
            _allLaunchesPage = new AllLaunchesPage(driver);
            _waiter = new Waiter(driver);

        }

        public AllLaunchesPage EnterLaunchName(string launchName)
        {
            _waiter.WaitFor(() => _allLaunchesPage.LaunchNameField.Enabled);
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Enter launch name"));
            _allLaunchesPage.EnterLaunchName(launchName);
            return _allLaunchesPage;
        }

        public AllLaunchesPage ClickOnFilterByButton()
        {
            _waiter.WaitFor(() => _allLaunchesPage.AddFilterButton.Enabled);
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Click on filter button"));
            _allLaunchesPage.AddFilterButton.Click();
            return _allLaunchesPage;
        }

        public bool CheckLaunchName(string name)
        {
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Check launch name"));
            return _allLaunchesPage.launchNames.First().Text.Contains(name);
        }

        public AllLaunchesPage ChooseFilterByTotal()
        {
            _waiter.WaitFor(() => _allLaunchesPage.MoreButton.Enabled);
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Click on More button"));
            _allLaunchesPage.MoreButton.Click();
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Choose Total"));
            _waiter.WaitFor(() => _allLaunchesPage.TotalCheckbox.Enabled);
            _allLaunchesPage.TotalCheckbox.Click();
            return _allLaunchesPage;
        }

        public AllLaunchesPage ChooseFilterByPassed()
        {
            _waiter.WaitFor(() => _allLaunchesPage.MoreButton.Enabled);
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Click on More button"));
            _allLaunchesPage.MoreButton.Click();
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Choose Passe"));
            _waiter.WaitFor(() => _allLaunchesPage.PassedCheckbox.Enabled);
            _allLaunchesPage.PassedCheckbox.Click();
            return _allLaunchesPage;
        }

        public AllLaunchesPage EnterSecondFilterField(string value)
        {
            _waiter.WaitFor(() => _allLaunchesPage.SecondFilterField.Enabled);
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Enter launch name"));
            _allLaunchesPage.EnterSecondFilterField(value);
            return _allLaunchesPage;
        }

        public AllLaunchesPage SelectEqual()
        {
            _logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "SelectEqual"));
            _waiter.WaitFor(() => _allLaunchesPage.Condition.Enabled);
            _allLaunchesPage.ClickCondition();
            _waiter.WaitFor(() => _allLaunchesPage.EqualCondition.Enabled);
            _allLaunchesPage.ClickEqualCondition();
            return _allLaunchesPage;
        }

        public bool CheckTotalValue(string total)
        {
            Thread.Sleep(1000);
            return _allLaunchesPage.TotalValues.First().Text.Contains(total);
        }

        public bool CheckPassedValue(string passed)
        {
            Thread.Sleep(1000);
            return _allLaunchesPage.PassedValues.First().Text.Contains(passed);
        }
    }
}
