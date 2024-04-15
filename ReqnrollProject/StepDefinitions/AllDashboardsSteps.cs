using Core.Helpers;
using Core.Logger;
using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;
using UI.Business.Pages;
namespace ReportPortal
{
    [Binding]
    public sealed class AllDashboardsSteps
    {
        private readonly IWebDriver _driver;
        private AllDashboardsPage _allDashboardsPage;
        public ConsoleLogger logger = new ConsoleLogger();
        public Settings settings = SettingHelper.LoadFromAppSettings();
        private AllLaunchesPage _allLaunchesPage;
        public Waiter waiter;

        public AllDashboardsSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<IWebDriver>();
            _allDashboardsPage = new AllDashboardsPage(_driver);
            waiter = new Waiter(_driver);
        }

        [Then("Is Launches Button Displayed")]
        public void IsLaunchesButtonDisplayed()
        {
            waiter.WaitFor(() => _allDashboardsPage.LaunchesButton.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Check Page"));
            Assert.IsTrue(_allDashboardsPage.LaunchesButton.Displayed);
        }

        [When("CLick On Launches Button")]
        public AllLaunchesPage CLickOnLaunchesButton()
        {
            waiter.WaitFor(() => _allDashboardsPage.LaunchesButton.Enabled);
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Click on launch button"));
            _allDashboardsPage.LaunchesButton.Click();
            return _allLaunchesPage;
        }
    }
}