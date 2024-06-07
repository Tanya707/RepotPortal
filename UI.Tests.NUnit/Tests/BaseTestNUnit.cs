using Core.Driver;
using Core.Helpers;
using Core.Models;
using NUnit.Framework.Interfaces;
using UI.Business.Steps;

namespace UI.Tests.NUnit.Tests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [TestFixture]
    public abstract class BaseTestNUnit
    {
        private WebDriverFactory _webDriverFactory;
        protected Settings settings = SettingHelper.LoadFromAppSettings();
        protected ConfigSettings configs = SettingHelper.LoadFromConfigSettings();
        protected LoginTestSteps loginPage => new LoginTestSteps(_webDriverFactory.GetDriver());
        protected MenuSteps menuPage => new MenuSteps(_webDriverFactory.GetDriver());
        protected AllLaunchesSteps allLaunchesPage => new AllLaunchesSteps(_webDriverFactory.GetDriver());

        [SetUp]
        public void SetUp()
        {
            _webDriverFactory = new WebDriverFactory();
            _webDriverFactory.InitializeDriver(configs.Browser);
            _webDriverFactory.WindowMaximize();
        }

        [TearDown]
        public void TearDown()
        {
            var testResult = TestContext.CurrentContext.Result.Outcome.Status;
            var testCaseIds = TestContext.CurrentContext.Test.Properties["TestCaseId"].ToList();
            if (testCaseIds.Any())
            {
                JiraClient.UpdateTestCaseStatus(testCaseIds.Single().ToString(), testResult);
            }
            var result = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed
                ? "Passed"
                : "Failed";

            _webDriverFactory.CloseDriverAndFinishHim();
        }

    }
}
