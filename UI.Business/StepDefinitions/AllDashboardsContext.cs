using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;
using UI.Business.Pages;

namespace UI.Business.StepDefinitions
{
    [Binding]
    public sealed class AllDashboardsContext:BaseContext
    {
        public AllDashboardsContext(ScenarioContext scenarioContext) : base(scenarioContext) { }


        [Then("Is Launches Button Displayed")]
        public void IsLaunchesButtonDisplayed()
        {
            _waiter.WaitFor(() => _allDashboardsPage.LaunchesButton.Enabled());
            Assert.IsTrue(_allDashboardsPage.LaunchesButton.Displayed());
        }

        [When("CLick On Launches Button")]
        public AllLaunchesPage CLickOnLaunchesButton()
        {
            _waiter.WaitFor(() => _allDashboardsPage.LaunchesButton.Enabled());
            _allDashboardsPage.LaunchesButton.Click();
            return _allLaunchesPage;
        }
    }
}