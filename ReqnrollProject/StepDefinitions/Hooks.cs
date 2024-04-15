using Core.Helpers;
using Core.Models;
using Framework.Core.Utilities;
using OpenQA.Selenium;
using ReportPortal;
using Reqnroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Business.Driver;
using UI.Business.Pages;

namespace ReqnrollProject.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        readonly ScenarioContext _scenarioContext;
        protected WebDriverFactory _webDriverFactory;

        public Hooks(WebDriverFactory webDriverFactory, ScenarioContext scenarioContext)
        {
            _webDriverFactory = webDriverFactory;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void SetUp()
        {    
            _webDriverFactory.InitializeDriver(BrowserList.Chrome);
            _webDriverFactory.WindowMaximise();
            var driver = _webDriverFactory.GetDriver();
            _scenarioContext.Set(driver);
        }

        [AfterScenario]
        public void TearDown()
        {
            _webDriverFactory.CloseDriver();
            _webDriverFactory.FinishHim();
        }
    }
}
