using Framework.Core.Contexts;
using Framework.Core.Tests;
using Framework.Core.Utilities;
using OpenQA.Selenium;
using Reqnroll;
//using TechTalk.SpecFlow;
namespace ReportPortal
{
    public class LoginTestContext
    {
        private LoginContext loginContext => new();

        [Given(@"Open page")]
        public LoginContext LogInTest()
        {
            //Browser.NavigateTo("https://rp.epam.com");
            return loginContext;
        }

        [Then(@"Check button")]
        public void logInWithEpamCheck()
        {
            var logInWithEpam = LogInTest().LogInWithEpam.Displayed;
        }
    }
}