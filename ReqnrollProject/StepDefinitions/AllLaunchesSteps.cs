using Core.Helpers;
using Core.Logger;
using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;
using UI.Business.Pages;

namespace UI.Business.Steps
{
    [Binding]
    public sealed class AllLaunchesSteps
    {
        private readonly IWebDriver _driver;
        private AllDashboardsPage _allDashboardsPage;
        private AllLaunchesPage _allLaunchesPage;
        public ConsoleLogger logger = new ConsoleLogger();
        public Settings settings = SettingHelper.LoadFromAppSettings();
        public Waiter waiter;

        public AllLaunchesSteps(ScenarioContext scenarioContext) {

            _driver = scenarioContext.Get<IWebDriver>();
            _allDashboardsPage = new AllDashboardsPage(_driver);
            _allLaunchesPage = new AllLaunchesPage(_driver);
            waiter = new Waiter(_driver);

        }

        [When("Enter Launch Name {string}")]
        public AllLaunchesPage EnterLaunchName(string launchName)
        {
            waiter.WaitFor(() => _allLaunchesPage.LaunchNameField.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Enter launch name"));
            _allLaunchesPage.EnterLaunchName(launchName);
            return _allLaunchesPage;
        }

        [When("Click On Filter By Button")]
        public AllLaunchesPage ClickOnFilterByButton()
        {
            waiter.WaitFor(() => _allLaunchesPage.AddFilterButton.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Click on filter button"));
            _allLaunchesPage.AddFilterButton.Click();
            return _allLaunchesPage;
        }

        [Then("Check Launch Names {string}")]
        public void CheckLaunchNames(string launchName)
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Check launch name"));
            Thread.Sleep(5000);
            Assert.IsTrue(_allLaunchesPage.launchNames.First().Text.Contains(launchName));
        }

        [When("Choose Filter By Total")]
        public AllLaunchesPage ChooseFilterByTotal()
        {
            waiter.WaitFor(() => _allLaunchesPage.MoreButton.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Click on More button"));
            _allLaunchesPage.MoreButton.Click();
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Choose Total"));
            waiter.WaitFor(() => _allLaunchesPage.TotalCheckbox.Enabled);
            _allLaunchesPage.TotalCheckbox.Click();
            return _allLaunchesPage;
        }

        [When("Choose Filter By Passed")]
        public AllLaunchesPage ChooseFilterByPassed()
        {
            waiter.WaitFor(() => _allLaunchesPage.MoreButton.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Click on More button"));
            _allLaunchesPage.MoreButton.Click();
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Choose Passe"));
            waiter.WaitFor(() => _allLaunchesPage.PassedCheckbox.Enabled);
            _allLaunchesPage.PassedCheckbox.Click();
            return _allLaunchesPage;
        }

        [When("Enter Second Filter Field {string}")]
        public AllLaunchesPage EnterSecondFilterField(string value)
        {
            waiter.WaitFor(() => _allLaunchesPage.SecondFilterField.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Enter launch name"));
            _allLaunchesPage.EnterSecondFilterField(value);
            return _allLaunchesPage;
        }

        [When("Select Equal")]
        public AllLaunchesPage SelectEqual()
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "SelectEqual"));
            waiter.WaitFor(() => _allLaunchesPage.Condition.Enabled);
            _allLaunchesPage.ClickCondition();
            waiter.WaitFor(() => _allLaunchesPage.EqualCondition.Enabled);
            _allLaunchesPage.ClickEqualCondition();
            return _allLaunchesPage;
        }

        [Then("Check Total Values {string}")]
        public void CheckTotalValues(string total)
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Check total value"));
            Thread.Sleep(1000);
            Assert.IsTrue(_allLaunchesPage.TotalValues.First().Text.Contains(total));
        }

        [Then("Check Passed Values {string}")]
        public void CheckPassedValues(string passed)
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Check passed value"));
            Thread.Sleep(1000);
            Assert.IsTrue(_allLaunchesPage.PassedValues.First().Text.Contains(passed));
        }
    }
}
