﻿using Core.Driver;
using Core.Logger;
using OpenQA.Selenium;
using Reqnroll;
using UI.Business.Pages;

namespace UI.Business.StepDefinitions
{
    public abstract class BaseContext
    {
        protected MenuPage _menuPage;
        protected AllLaunchesPage _allLaunchesPage;
        protected LoginPage _loginPage;
        protected WebDriverWaiter _waiter;
        protected ILogger _logger = new ConsoleLogger();
        private readonly IWebDriver _driver;

        protected BaseContext(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<IWebDriver>();
            _menuPage = new MenuPage(_driver);
            _allLaunchesPage = new AllLaunchesPage(_driver);
            _loginPage = new LoginPage(_driver);
            _waiter = new WebDriverWaiter(_driver);

        }
    }
}
