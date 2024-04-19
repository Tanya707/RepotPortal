﻿using Core.Helpers;
using Core.Logger;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Business.Pages;

namespace UI.Business.Steps
{
    public abstract class BaseSteps
    {
        protected AllDashboardsPage _allDashboardsPage;
        protected AllLaunchesPage _allLaunchesPage;
        protected LoginPage _loginPage;
        protected Waiter _waiter;
        protected ILogger _logger = new ConsoleLogger();
        protected IWebDriver _driver;
        protected BaseSteps(IWebDriver driver)
        {
            _allDashboardsPage = new AllDashboardsPage(driver);
            _allLaunchesPage = new AllLaunchesPage(driver);
            _loginPage = new LoginPage(driver);
            _waiter = new Waiter(driver);
        }
    }
}
