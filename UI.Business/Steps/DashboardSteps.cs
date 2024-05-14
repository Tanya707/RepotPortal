using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;

namespace UI.Business.Steps
{
    public class DashboardSteps : BaseSteps
    {
        public DashboardSteps(IWebDriver driver) : base(driver) { }

        public DashboardPage ChangePlacesOfTwoTables(int firstTable, int secondTable)
        {
            //_waiter.WaitFor(() => _dashboardPage.DashboardTables.First().DashboardNameDisplayed());
            LogInfoExtensions.LogInfo(_logger, "Change places of two tables");
            _dashboardPage.DragAndDropElements(firstTable, secondTable);
            return _dashboardPage;
        }

        //public AllLaunchesPage ClickOnFilterByButton()
        //{
        //    _waiter.WaitFor(() => _allLaunchesPage.AddFilterButton.Enabled());
        //    LogInfoExtensions.LogInfo(_logger, "Click on filter button");
        //    _allLaunchesPage.AddFilterButton.Click();
        //    return _allLaunchesPage;
        //}

        //public bool CheckLaunchName(string name)
        //{
        //    return _allLaunchesPage.LaunchNames.First().GetText().Contains(name);
        //}

        //public AllLaunchesPage ChooseFilterByTotal()
        //{
        //    _waiter.WaitFor(() => _allLaunchesPage.MoreButton.Enabled());
        //    LogInfoExtensions.LogInfo(_logger, "Click on More button");
        //    _allLaunchesPage.MoreButton.Click();
        //    LogInfoExtensions.LogInfo(_logger, "Choose Total");
        //    _waiter.WaitFor(() => _allLaunchesPage.TotalCheckbox.Enabled());
        //    _allLaunchesPage.TotalCheckbox.Check();
        //    return _allLaunchesPage;
        //}

        //public AllLaunchesPage ChooseFilterByPassed()
        //{
        //    _waiter.WaitFor(() => _allLaunchesPage.MoreButton.Enabled());
        //    LogInfoExtensions.LogInfo(_logger,"Click on More button");
        //    _allLaunchesPage.MoreButton.Click();
        //    LogInfoExtensions.LogInfo(_logger, "Choose Passe");
        //    _waiter.WaitFor(() => _allLaunchesPage.PassedCheckbox.Enabled());
        //    _allLaunchesPage.PassedCheckbox.Check();
        //    return _allLaunchesPage;
        //}

        //public AllLaunchesPage EnterSecondFilterField(string value)
        //{
        //    _waiter.WaitFor(() => _allLaunchesPage.SecondFilterField.Enabled());
        //    LogInfoExtensions.LogInfo(_logger, "Enter launch name");
        //    _allLaunchesPage.EnterSecondFilterField(value);
        //    return _allLaunchesPage;
        //}

        //public AllLaunchesPage SelectEqual()
        //{
        //    LogInfoExtensions.LogInfo(_logger, "SelectEqual");
        //    _waiter.WaitFor(() => _allLaunchesPage.Condition.Enabled());
        //    _allLaunchesPage.ClickCondition();
        //    _waiter.WaitFor(() => _allLaunchesPage.EqualCondition.Enabled());
        //    _allLaunchesPage.ClickEqualCondition();
        //    return _allLaunchesPage;
        //}

        //public bool CheckTotalValue(string total)
        //{
        //    _waiter.WaitForStaleElementReferenceException(_allLaunchesPage.TotalValues.First());
        //    return _allLaunchesPage.TotalValues.First().GetText().Contains(total);
        //}

        //public bool CheckPassedValue(string passed)
        //{
        //    _waiter.WaitForStaleElementReferenceException(_allLaunchesPage.PassedValues.First());
        //    return _allLaunchesPage.PassedValues.First().GetText().Contains(passed);
        //}

        //public AllLaunchesPage ScrollPageSizeButtonIntoView()
        //{
        //    LogInfoExtensions.LogInfo(_logger, "Scroll PageSiz Button Into View");
        //    _allLaunchesPage.ScrollPageSizeButtonIntoView();
        //    return _allLaunchesPage;
        //}

        //public bool IsPageSizeButtonScrolledIntoView()
        //{
        //    return _allLaunchesPage.IsPageSizeButtonScrolledIntoView();
        //}
    }
}
