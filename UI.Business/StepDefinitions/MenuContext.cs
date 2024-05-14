using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;
using UI.Business.Pages;

namespace UI.Business.StepDefinitions
{
    [Binding]
    public sealed class MenuContext:BaseContext
    {
        public MenuContext(ScenarioContext scenarioContext) : base(scenarioContext) { }


        [Then("Is Launches Button Displayed")]
        public void IsLaunchesButtonDisplayed()
        {
            _waiter.WaitFor(() => _menuPage.LaunchesButton.Enabled());
            Assert.IsTrue(_menuPage.LaunchesButton.Displayed());
        }

        [When("CLick On Launches Button")]
        public AllLaunchesPage CLickOnLaunchesButton()
        {
            _waiter.WaitFor(() => _menuPage.LaunchesButton.Enabled());
            _menuPage.LaunchesButton.Click();
            return _allLaunchesPage;
        }
    }
}