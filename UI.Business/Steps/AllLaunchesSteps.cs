using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;

namespace UI.Business.Steps
{
    public class AllLaunchesSteps:BaseSteps
    {
        public AllLaunchesSteps(IWebDriver driver) : base(driver) { }

        public AllLaunchesPage EnterLaunchName(string launchName)
        {
            _waiter.WaitFor(() => _allLaunchesPage.LaunchNameField.Enabled());
            _logger.LogInfo("Enter launch name");
            _allLaunchesPage.EnterLaunchName(launchName);
            return _allLaunchesPage;
        }

        public AllLaunchesPage ClickOnFilterByButton()
        {
            _waiter.WaitFor(() => _allLaunchesPage.AddFilterButton.Enabled());
            _logger.LogInfo("Click on filter button");
            _allLaunchesPage.ClickAddFilterButton();
            return _allLaunchesPage;
        }

        public bool CheckLaunchName(string name)
        {
            return _allLaunchesPage.LaunchNames().First().GetText().Contains(name);
        }

        public AllLaunchesPage ChooseFilterByTotal()
        {
            _waiter.WaitFor(() => _allLaunchesPage.MoreButton.Enabled());
            _logger.LogInfo( "Click on More button");
            _allLaunchesPage.MoreButton.Click();
            _logger.LogInfo( "Choose Total");
            _waiter.WaitFor(() => _allLaunchesPage.TotalCheckbox.Enabled());
            _allLaunchesPage.ClickTotalCheckbox();
            return _allLaunchesPage;
        }

        public AllLaunchesPage ChooseFilterByPassed()
        {
            _waiter.WaitFor(() => _allLaunchesPage.MoreButton.Enabled());
            _logger.LogInfo("Click on More button");
            _allLaunchesPage.MoreButton.Click();
            _logger.LogInfo( "Choose Passe");
            _waiter.WaitFor(() => _allLaunchesPage.PassedCheckbox.Enabled());
            _allLaunchesPage.ClickPassedCheckbox();
            return _allLaunchesPage;
        }

        public AllLaunchesPage EnterSecondFilterField(string value)
        {
            _waiter.WaitFor(() => _allLaunchesPage.SecondFilterField.Enabled());
            _logger.LogInfo("Enter launch name");
            _allLaunchesPage.EnterSecondFilterField(value);
            return _allLaunchesPage;
        }

        public AllLaunchesPage SelectEqual()
        {
            _logger.LogInfo( "SelectEqual");
            _waiter.WaitFor(() => _allLaunchesPage.Condition.Enabled());
            _allLaunchesPage.ClickCondition();
            _waiter.WaitFor(() => _allLaunchesPage.EqualCondition.Enabled());
            _allLaunchesPage.ClickEqualCondition();
            return _allLaunchesPage;
        }

        public bool CheckTotalValue(string total)
        {
            _waiter.WaitForElementDisappared(_allLaunchesPage.TotalValues().First());
            return _allLaunchesPage.TotalValues().First().GetText().Contains(total);
        }

        public bool CheckPassedValue(string passed)
        {
            _waiter.WaitForElementDisappared(_allLaunchesPage.PassedValues().First());
            return _allLaunchesPage.PassedValues().First().GetText().Contains(passed);
        }

        public AllLaunchesPage ScrollPageSizeButtonIntoView()
        {
            _logger.LogInfo( "Scroll PageSiz Button Into View");
            _allLaunchesPage.ScrollPageSizeButtonIntoView();
            return _allLaunchesPage;
        }

        public bool IsPageSizeButtonScrolledIntoView()
        {
            return _allLaunchesPage.IsPageSizeButtonScrolledIntoView();
        }

        public AllLaunchesPage CheckAllLaunches()
        {
            _waiter.WaitFor(() => _allLaunchesPage.CheckAllButton.Enabled());
            _logger.LogInfo( "Check all launches");
            _allLaunchesPage.CheckAllLaunches();
            return _allLaunchesPage;
        }

        public AllLaunchesPage CheckFirstLaunch()
        {
            _waiter.WaitFor(() => _allLaunchesPage.Launches.First().SelectCheckBox.Enabled());
            _logger.LogInfo("Check first launch");
            _allLaunchesPage.Launches.First().SelectCheckBox.Check();
            return _allLaunchesPage;
        }

        public DeleteLaunchesPage ClickOnDeleteButton()
        {
            _waiter.WaitFor(() => _allLaunchesPage.ActionsButton.Enabled());
            _logger.LogInfo("Click on action button");
            _allLaunchesPage.ClickOnActionButton();
            _logger.LogInfo("Click on delete button");
            _allLaunchesPage.ClickDeleteButton();
            return _deleteLaunchesPage;
        }


        public CompareLaunchesPage ClickOnCompareButton()
        {
            _waiter.WaitFor(() => _allLaunchesPage.ActionsButton.Enabled());
            _logger.LogInfo("Click on action button");
            _allLaunchesPage.ClickOnActionButton();
            _logger.LogInfo("Click on compare button");
            _allLaunchesPage.ClickCompareButton();
            return _compareLaunchesPage;
        }

        public bool IsTotalValuesContainsAllLaunches()
        {
            return _allLaunchesPage.Launches.Count.Equals(_allLaunchesPage.TotalValues().Count);
        }

        public bool IsPassedValuesContainsAllLaunches()
        {
            return _allLaunchesPage.Launches.Count.Equals(_allLaunchesPage.PassedValues().Count);
        }

        public bool IsFailedValuesContainsAllLaunches()
        {
            return _allLaunchesPage.Launches.Count.Equals(_allLaunchesPage.FailedValues().Count);
        }

        public int CountOfLaunches()
        {
           
            return _allLaunchesPage.Launches.Count;
        }
    }
}
