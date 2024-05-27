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
            LogInfoExtensions.LogInfo(_logger, "Enter launch name");
            _allLaunchesPage.EnterLaunchName(launchName);
            return _allLaunchesPage;
        }

        public AllLaunchesPage ClickOnFilterByButton()
        {
            _waiter.WaitFor(() => _allLaunchesPage.AddFilterButton.Enabled());
            LogInfoExtensions.LogInfo(_logger, "Click on filter button");
            _allLaunchesPage.ClickAddFilterButton();
            return _allLaunchesPage;
        }

        public bool CheckLaunchName(string name)
        {
            return _allLaunchesPage.LaunchNames.First().GetText().Contains(name);
        }

        public AllLaunchesPage ChooseFilterByTotal()
        {
            _waiter.WaitFor(() => _allLaunchesPage.MoreButton.Enabled());
            LogInfoExtensions.LogInfo(_logger, "Click on More button");
            _allLaunchesPage.MoreButton.Click();
            LogInfoExtensions.LogInfo(_logger, "Choose Total");
            _waiter.WaitFor(() => _allLaunchesPage.TotalCheckbox.Enabled());
            _allLaunchesPage.ClickTotalCheckbox();
            return _allLaunchesPage;
        }

        public AllLaunchesPage ChooseFilterByPassed()
        {
            _waiter.WaitFor(() => _allLaunchesPage.MoreButton.Enabled());
            LogInfoExtensions.LogInfo(_logger,"Click on More button");
            _allLaunchesPage.MoreButton.Click();
            LogInfoExtensions.LogInfo(_logger, "Choose Passe");
            _waiter.WaitFor(() => _allLaunchesPage.PassedCheckbox.Enabled());
            _allLaunchesPage.ClickPassedCheckbox();
            return _allLaunchesPage;
        }

        public AllLaunchesPage EnterSecondFilterField(string value)
        {
            _waiter.WaitFor(() => _allLaunchesPage.SecondFilterField.Enabled());
            LogInfoExtensions.LogInfo(_logger, "Enter launch name");
            _allLaunchesPage.EnterSecondFilterField(value);
            return _allLaunchesPage;
        }

        public AllLaunchesPage SelectEqual()
        {
            LogInfoExtensions.LogInfo(_logger, "SelectEqual");
            _waiter.WaitFor(() => _allLaunchesPage.Condition.Enabled());
            _allLaunchesPage.ClickCondition();
            _waiter.WaitFor(() => _allLaunchesPage.EqualCondition.Enabled());
            _allLaunchesPage.ClickEqualCondition();
            return _allLaunchesPage;
        }

        public bool CheckTotalValue(string total)
        {
            _waiter.WaitForElementDisappared(_allLaunchesPage.TotalValues.First());
            return _allLaunchesPage.TotalValues.First().GetText().Contains(total);
        }

        public bool CheckPassedValue(string passed)
        {
            _waiter.WaitForElementDisappared(_allLaunchesPage.PassedValues.First());
            return _allLaunchesPage.PassedValues.First().GetText().Contains(passed);
        }

        public AllLaunchesPage ScrollPageSizeButtonIntoView()
        {
            LogInfoExtensions.LogInfo(_logger, "Scroll PageSiz Button Into View");
            _allLaunchesPage.ScrollPageSizeButtonIntoView();
            return _allLaunchesPage;
        }

        public bool IsPageSizeButtonScrolledIntoView()
        {
            return _allLaunchesPage.IsPageSizeButtonScrolledIntoView();
        }
    }
}
