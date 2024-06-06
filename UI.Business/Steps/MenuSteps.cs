using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;

namespace UI.Business.Steps
{
    public class MenuSteps:BaseSteps
    {
        public MenuSteps(IWebDriver driver) : base(driver) { }

        public bool IsLaunchesButtonDisplayed()
        {
            _waiter.WaitFor(() => _menuPage.LaunchesButton.Enabled());
            return _menuPage.LaunchesButton.Displayed();
        }

        public AllLaunchesPage CLickOnLaunchesButton()
        {
            _waiter.WaitFor(() => _menuPage.LaunchesButton.Enabled());
            LogInfoExtensions.LogInfo(_logger, "Click on launch button");
            _menuPage.LaunchesButton.Click();
            return _allLaunchesPage;
        }
        public AllLaunchesPage CLickOnLaunchesButtonJS()
        {
            _waiter.WaitFor(() => _menuPage.LaunchesButton.Enabled());
            LogInfoExtensions.LogInfo(_logger, "Click on launch button");
            _menuPage.ClickOnLaunchButtonWithJs();
            return _allLaunchesPage;
        }

        public AllDashboardsPage CLickOnAllDashboardsButton()
        {
            _waiter.WaitFor(() => _menuPage.DashboardButton.Enabled());
            LogInfoExtensions.LogInfo(_logger, "Click on Dashboard button");
            _menuPage.DashboardButton.Click();
            return _allDashboardsPage;
        }
    }
}