﻿using Core.Helpers;
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
            _waiter.WaitFor(() => _allLaunchesPage.LaunchNameField.Enabled);
            LogInfoExtensions.Log(_logger, "Enter launch name");
            _allLaunchesPage.EnterLaunchName(launchName);
            return _allLaunchesPage;
        }

        public AllLaunchesPage ClickOnFilterByButton()
        {
            _waiter.WaitFor(() => _allLaunchesPage.AddFilterButton.Enabled);
            LogInfoExtensions.Log(_logger, "Click on filter button");
            _allLaunchesPage.AddFilterButton.Click();
            return _allLaunchesPage;
        }

        public bool CheckLaunchName(string name)
        {
            return _allLaunchesPage.launchNames.First().Text.Contains(name);
        }

        public AllLaunchesPage ChooseFilterByTotal()
        {
            _waiter.WaitFor(() => _allLaunchesPage.MoreButton.Enabled);
            LogInfoExtensions.Log(_logger, "Click on More button");
            _allLaunchesPage.MoreButton.Click();
            LogInfoExtensions.Log(_logger, "Choose Total");
            _waiter.WaitFor(() => _allLaunchesPage.TotalCheckbox.Enabled);
            _allLaunchesPage.TotalCheckbox.Click();
            return _allLaunchesPage;
        }

        public AllLaunchesPage ChooseFilterByPassed()
        {
            _waiter.WaitFor(() => _allLaunchesPage.MoreButton.Enabled);
            LogInfoExtensions.Log(_logger,"Click on More button");
            _allLaunchesPage.MoreButton.Click();
            LogInfoExtensions.Log(_logger, "Choose Passe");
            _waiter.WaitFor(() => _allLaunchesPage.PassedCheckbox.Enabled);
            _allLaunchesPage.PassedCheckbox.Click();
            return _allLaunchesPage;
        }

        public AllLaunchesPage EnterSecondFilterField(string value)
        {
            _waiter.WaitFor(() => _allLaunchesPage.SecondFilterField.Enabled);
            LogInfoExtensions.Log(_logger, "Enter launch name");
            _allLaunchesPage.EnterSecondFilterField(value);
            return _allLaunchesPage;
        }

        public AllLaunchesPage SelectEqual()
        {
            LogInfoExtensions.Log(_logger, "SelectEqual");
            _waiter.WaitFor(() => _allLaunchesPage.Condition.Enabled);
            _allLaunchesPage.ClickCondition();
            _waiter.WaitFor(() => _allLaunchesPage.EqualCondition.Enabled);
            _allLaunchesPage.ClickEqualCondition();
            return _allLaunchesPage;
        }

        public bool CheckTotalValue(string total)
        {
            _waiter.WaitForStaleElementReferenceException(_allLaunchesPage.TotalValues.First());
            return _allLaunchesPage.TotalValues.First().Text.Contains(total);
        }

        public bool CheckPassedValue(string passed)
        {
            _waiter.WaitForStaleElementReferenceException(_allLaunchesPage.PassedValues.First());
            return _allLaunchesPage.PassedValues.First().Text.Contains(passed);
        }
    }
}