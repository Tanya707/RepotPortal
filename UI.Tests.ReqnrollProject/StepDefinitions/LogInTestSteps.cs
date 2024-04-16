using Core.Helpers;
using Core.Logger;
using Core.Models;
using Framework.Core.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Reqnroll;
using UI.Business.Pages;

namespace ReqnrollProject.StepDefinitions
{
    [Binding]
    public sealed class LogInTestSteps
    {
        private readonly IWebDriver _driver;
        private LoginPage _loginPage;
        private AllDashboardsPage _allDashboardsPage;
        public ConsoleLogger logger = new ConsoleLogger();
        public Settings settings = SettingHelper.LoadFromAppSettings();

        public LogInTestSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<IWebDriver>();
            _loginPage = new LoginPage(_driver);
        }


        [Given("Open Log In Page")]
        public LoginPage OpenLogInPage()
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Open page"));
            _loginPage.GoToBaseUrl(settings.ReportPortalUrl.LocalBaseUrl);
            return _loginPage;
        }

        [Then("Is Log In Button Displayed")]
        public void IsLogInButtonDisplayed()
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Check button"));
            Assert.IsTrue(_loginPage.LogInButton.Displayed);
        }

        [When("Log In Superadmin")]
        public AllDashboardsPage LogInSuperadmin()
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Enter credentials"));
            _loginPage.EnterLogin(settings.SuperadminUser.UserName);
            _loginPage.EnterPassword(settings.SuperadminUser.Password);
            _loginPage.LogInButton.Click();
            return _allDashboardsPage;
        }

        [When("Log In DefaultUser")]
        public AllDashboardsPage LogInDefaultUser()
        {
            logger.Log(new Core.Logger.LogEntry(LoggingEventType.Information, "Enter credentials"));
            _loginPage.EnterLogin(settings.DefaultUser.UserName);
            _loginPage.EnterPassword(settings.DefaultUser.Password);
            _loginPage.LogInButton.Click();
            return _allDashboardsPage;
        }
    }
}
