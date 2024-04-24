using Core.Helpers;
using Core.Models;
using Core.WebDriverFactory;
using UI.Business.Steps;

namespace UI.Tests.NUnit
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [TestFixture]
    public abstract class BaseTestNUnit
    {
        private WebDriverFactory webDriverFactory;
        protected Settings settings = SettingHelper.LoadFromAppSettings();
        protected ConfigSettings configs = SettingHelper.LoadFromConfigSettings();
        protected LoginTestSteps loginPage => new LoginTestSteps(webDriverFactory.GetDriver());
        protected AllDashboardsSteps allDashboardsPage => new AllDashboardsSteps(webDriverFactory.GetDriver());
        protected AllLaunchesSteps allLaunchesPage => new AllLaunchesSteps(webDriverFactory.GetDriver());

        [SetUp]
        public void SetUp()
        {
            webDriverFactory = new WebDriverFactory();
            webDriverFactory.InitializeDriver(configs.Browser);
            webDriverFactory.WindowMaximize();
        }

        [TearDown]
        public void TearDown()
        {
            webDriverFactory.CloseDriverAndFinishHim();
        }

    }
}
