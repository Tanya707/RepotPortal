using Core.Helpers;
using Core.Logger;
using OpenQA.Selenium;
using Reqnroll;
using UI.Business.Pages;

namespace UI.Business.StepsDefinitions
{
    public abstract class BaseContext
    {
        protected AllDashboardsPage _allDashboardsPage;
        protected AllLaunchesPage _allLaunchesPage;
        protected LoginPage _loginPage;
        protected Waiter _waiter;
        protected ILogger _logger = new ConsoleLogger();
        private readonly IWebDriver _driver;
        protected BaseContext(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<IWebDriver>();
            _allDashboardsPage = new AllDashboardsPage(_driver);
            _allLaunchesPage = new AllLaunchesPage(_driver);
            _loginPage = new LoginPage(_driver);
            _waiter = new Waiter(_driver);

        }
    }
}
