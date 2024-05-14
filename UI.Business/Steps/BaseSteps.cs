using Core.Driver;
using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;

namespace UI.Business.Steps
{
    public abstract class BaseSteps
    {
        protected MenuPage _menuPage;
        protected AllLaunchesPage _allLaunchesPage;
        protected LoginPage _loginPage;
        protected WebDriverWaiter _waiter;
        protected AllDashboardsPage _allDashboardsPage;
        protected DashboardPage _dashboardPage;
        protected ILogger _logger = new ConsoleLogger();
        protected BaseSteps(IWebDriver driver)
        {
            _menuPage = new MenuPage(driver);
            _allLaunchesPage = new AllLaunchesPage(driver);
            _allDashboardsPage = new AllDashboardsPage(driver);
            _dashboardPage = new DashboardPage(driver);
            _loginPage = new LoginPage(driver);
            _waiter = new WebDriverWaiter(driver);
        }
    }
}
