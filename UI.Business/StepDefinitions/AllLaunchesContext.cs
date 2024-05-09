using Core.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;
using UI.Business.Pages;

namespace UI.Business.StepDefinitions
{
    [Binding]
    public sealed class AllLaunchesContext:BaseContext
    {
        public AllLaunchesContext(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [When("Enter Launch Name {string}")]
        public AllLaunchesPage EnterLaunchName(string launchName)
        {
            _waiter.WaitFor(() => _allLaunchesPage.LaunchNameField.Enabled);
            LogInfoExtensions.LogDebug(_logger, $"Enter Launch Name {launchName}");
            _allLaunchesPage.EnterLaunchName(launchName);
            return _allLaunchesPage;
        }

        [When("Click On Filter By Button")]
        public AllLaunchesPage ClickOnFilterByButton()
        {
            _waiter.WaitFor(() => _allLaunchesPage.AddFilterButton.Enabled);
            _allLaunchesPage.AddFilterButton.Click();
            return _allLaunchesPage;
        }

        [Then("Check Launch Names {string} contains")]
        public void CheckLaunchNameContains(string launchName)
        {
            _waiter.WaitForStaleElementReferenceException(_allLaunchesPage.LaunchNames.First());
            Assert.IsTrue(_allLaunchesPage.LaunchNames.First().Text.Contains(launchName));
        }

        [When("Choose Filter By Total")]
        public AllLaunchesPage ChooseFilterByTotal()
        {
            _waiter.WaitFor(() => _allLaunchesPage.MoreButton.Enabled);
            LogInfoExtensions.LogDebug(_logger, "Click on More button");
            _allLaunchesPage.MoreButton.Click();
            LogInfoExtensions.LogDebug(_logger, "Choose Total");
            _waiter.WaitFor(() => _allLaunchesPage.TotalCheckbox.Enabled);
            _allLaunchesPage.TotalCheckbox.Click();
            return _allLaunchesPage;
        }

        [When("Choose Filter By Passed")]
        public AllLaunchesPage ChooseFilterByPassed()
        {
            _waiter.WaitFor(() => _allLaunchesPage.MoreButton.Enabled);
            LogInfoExtensions.LogDebug(_logger, "Click on More button");
            _allLaunchesPage.MoreButton.Click();
            LogInfoExtensions.LogDebug(_logger, "Choose Passed");
            _waiter.WaitFor(() => _allLaunchesPage.PassedCheckbox.Enabled);
            _allLaunchesPage.PassedCheckbox.Click();
            return _allLaunchesPage;
        }

        [When("Enter Second Filter Field {string} {string}")]
        public AllLaunchesPage EnterSecondFilterField(string name,string value)
        {
            _waiter.WaitFor(() => _allLaunchesPage.SecondFilterField.Enabled);
            LogInfoExtensions.LogDebug(_logger, $"Enter {name}");
            _allLaunchesPage.EnterSecondFilterField(value);
            return _allLaunchesPage;
        }

        [When("Select Equal")]
        public AllLaunchesPage SelectEqual()
        {
            _waiter.WaitFor(() => _allLaunchesPage.Condition.Enabled);
            _allLaunchesPage.ClickCondition();
            _waiter.WaitFor(() => _allLaunchesPage.EqualCondition.Enabled);
            _allLaunchesPage.ClickEqualCondition();
            return _allLaunchesPage;
        }

        [Then("Check Total Values {string} contains")]
        public void CheckTotalValuesContains(string total)
        {
            _waiter.WaitForStaleElementReferenceException(_allLaunchesPage.TotalValues.First());
            Assert.IsTrue(_allLaunchesPage.TotalValues.First().Text.Contains(total));
        }

        [Then("Check Passed Values {string} contains")]
        public void CheckPassedValuesContains(string passed)
        {
            _waiter.WaitForStaleElementReferenceException(_allLaunchesPage.PassedValues.First());
            Assert.IsTrue(_allLaunchesPage.PassedValues.First().Text.Contains(passed));
        }

        [Then("Actions button is disabled by default")]
        public void ThenActionsButtonIsDisabledByDefault()
        {
            _allLaunchesPage.IsActionsDisabled();
        }
    }
}
