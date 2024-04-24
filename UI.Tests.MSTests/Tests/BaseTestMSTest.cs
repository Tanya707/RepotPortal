using Core.Helpers;
using Core.Models;
using Core.WebDriverFactory;
using UI.Business.Steps;

namespace UI.Tests.MSTests
{
    [TestClass]
    public class BaseTestMSTest
    {
        private WebDriverFactory webDriverFactory;
        protected Settings settings = SettingHelper.LoadFromAppSettings();
        protected ConfigSettings configs = SettingHelper.LoadFromConfigSettings();
        protected LoginTestSteps loginPage => new LoginTestSteps(webDriverFactory.GetDriver());
        protected AllDashboardsSteps allDashboardsPage => new AllDashboardsSteps(webDriverFactory.GetDriver());
        protected AllLaunchesSteps allLaunchesPage => new AllLaunchesSteps(webDriverFactory.GetDriver());

        [TestInitialize]
        public void SetUp()
        {
            webDriverFactory = new WebDriverFactory();
            webDriverFactory.InitializeDriver(configs.Browser);
            webDriverFactory.WindowMaximize();
        }

        [TestCleanup]
        public void TearDown()
        {
            webDriverFactory.CloseDriverAndFinishHim();
        }
    }
}
