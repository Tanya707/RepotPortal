using Core.Driver;
using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;

namespace UI.Business.Steps
{
    public abstract class BaseSteps
    {
        protected AllDashboardsPage _allDashboardsPage;
        protected AllLaunchesPage _allLaunchesPage;
        protected LoginPage _loginPage;
        protected WebDriverWaiter _waiter;
        protected ILogger _logger = new ConsoleLogger();
        protected BaseSteps(IWebDriver driver)
        {
            _allDashboardsPage = new AllDashboardsPage(driver);
            _allLaunchesPage = new AllLaunchesPage(driver);
            _loginPage = new LoginPage(driver);
            _waiter = new WebDriverWaiter(driver);
        }
    }
}
