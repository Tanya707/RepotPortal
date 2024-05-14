using Core.Helpers;
using Core.Logger;
using Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reqnroll;
using UI.Business.Pages;

namespace UI.Business.StepDefinitions
{
    [Binding]
    public sealed class LogInTestContext:BaseContext
    {
        private Settings _settings = SettingHelper.LoadFromAppSettings();

        public LogInTestContext(ScenarioContext scenarioContext) : base(scenarioContext) { }


        [Given("Open Log In Page")]
        public LoginPage OpenLogInPage()
        {
            LogInfoExtensions.LogDebug(_logger, $"Open page {_settings.ReportPortalUrl.LocalBaseUrl}");
            _loginPage.GoToBaseUrl(_settings.ReportPortalUrl.LocalBaseUrl);
            return _loginPage;
        }

        [Then("Is Log In Button Displayed")]
        public void IsLogInButtonDisplayed()
        {
            LogInfoExtensions.LogDebug(_logger, "Check button");
            Assert.IsTrue(_loginPage.LogInButton.Displayed());
        }

        [When("Log In Superadmin")]
        public MenuPage LogInSuperadmin()
        {
            LogInfoExtensions.LogDebug(_logger, $"Enter credentials username:{_settings.SuperadminUser.UserName}, password:{_settings.SuperadminUser.Password}");
            _loginPage.EnterLogin(_settings.SuperadminUser.UserName);
            _loginPage.EnterPassword(_settings.SuperadminUser.Password);
            _loginPage.LogInButton.Click();
            return _menuPage;
        }

        [When("Log In DefaultUser")]
        public MenuPage LogInDefaultUser()
        {
            LogInfoExtensions.LogDebug(_logger, $"Enter credentials username:{_settings.DefaultUser.UserName}, password:{_settings.DefaultUser.Password}");
            _loginPage.EnterLogin(_settings.DefaultUser.UserName);
            _loginPage.EnterPassword(_settings.DefaultUser.Password);
            _loginPage.LogInButton.Click();
            return _menuPage;
        }

        public void LogIn(string username, string password)
        {
            LogInfoExtensions.LogDebug(_logger, $"Enter credentials: username:{username}, password:{password}");
            _loginPage.EnterLogin(username);
            _loginPage.EnterPassword(password);
            _loginPage.LogInButton.Click();
            Assert.IsTrue(_loginPage.LogInButton.Displayed(), $"User can't log in with such credentials: username:{username}, password:{password}");
        }

        [When(@"I can log in with such data:")]
        public void ICanLogInWithSuchData(List<UserCredentials> credentials)
        {
            foreach (var row in credentials)
            {
                LogIn(row.UserName, row.Password);
            }
        }
    }
}
