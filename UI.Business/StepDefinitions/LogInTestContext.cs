using Core.Helpers;
using Core.Logger;
using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;
using UI.Business.Pages;

namespace UI.Business.StepsDefinitions
{
    [Binding]
    public sealed class LogInTestContext:BaseContext
    {
        private Settings _settings = SettingHelper.LoadFromAppSettings();

        public LogInTestContext(ScenarioContext scenarioContext) : base(scenarioContext) { }


        [Given("Open Log In Page")]
        public LoginPage OpenLogInPage()
        {
            LogInfoExtensions.LogInfo(_logger, "Open page");
            _loginPage.GoToBaseUrl(_settings.ReportPortalUrl.LocalBaseUrl);
            return _loginPage;
        }

        [Then("Is Log In Button Displayed")]
        public void IsLogInButtonDisplayed()
        {
            LogInfoExtensions.LogInfo(_logger, "Check button");
            Assert.IsTrue(_loginPage.LogInButton.Displayed);
        }

        [When("Log In Superadmin")]
        public AllDashboardsPage LogInSuperadmin()
        {
            LogInfoExtensions.LogInfo(_logger, "Enter credentials");
            _loginPage.EnterLogin(_settings.SuperadminUser.UserName);
            _loginPage.EnterPassword(_settings.SuperadminUser.Password);
            _loginPage.LogInButton.Click();
            return _allDashboardsPage;
        }

        [When("Log In DefaultUser")]
        public AllDashboardsPage LogInDefaultUser()
        {
            LogInfoExtensions.LogInfo(_logger, "Enter credentials");
            _loginPage.EnterLogin(_settings.DefaultUser.UserName);
            _loginPage.EnterPassword(_settings.DefaultUser.Password);
            _loginPage.LogInButton.Click();
            return _allDashboardsPage;
        }
    }
}
