using Core.Helpers;
using Core.Logger;
using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;
using UI.Business.Pages;

namespace UI.Business.StepsDefinitions
{
    [Binding]
    public sealed class AllDashboardsContext:BaseContext
    {
        public AllDashboardsContext(ScenarioContext scenarioContext) : base(scenarioContext) { }


        [Then("Is Launches Button Displayed")]
        public void IsLaunchesButtonDisplayed()
        {
            _waiter.WaitFor(() => _allDashboardsPage.LaunchesButton.Enabled);
            LogInfoExtensions.LogInfo(_logger, "Check Page");
            Assert.IsTrue(_allDashboardsPage.LaunchesButton.Displayed);
        }

        [When("CLick On Launches Button")]
        public AllLaunchesPage CLickOnLaunchesButton()
        {
            _waiter.WaitFor(() => _allDashboardsPage.LaunchesButton.Enabled);
            LogInfoExtensions.LogInfo(_logger, "Click on launch button");
            _allDashboardsPage.LaunchesButton.Click();
            return _allLaunchesPage;
        }
    }
}