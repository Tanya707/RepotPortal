using Core.Driver;
using Core.Helpers;
using Core.Models;
using UI.Business.Steps;

namespace UI.Tests.MSTests.Tests
{
    [TestClass]
    public class BaseTestMSTest
    {
        private WebDriverFactory _webDriverFactory;
        protected Settings settings = SettingHelper.LoadFromAppSettings();
        protected ConfigSettings configs = SettingHelper.LoadFromConfigSettings();
        protected LoginTestSteps loginPage => new LoginTestSteps(_webDriverFactory.GetDriver());
        protected AllDashboardsSteps allDashboardsPage => new AllDashboardsSteps(_webDriverFactory.GetDriver());
        protected AllLaunchesSteps allLaunchesPage => new AllLaunchesSteps(_webDriverFactory.GetDriver());

        [TestInitialize]
        public void SetUp()
        {
            _webDriverFactory = new WebDriverFactory();
            _webDriverFactory.InitializeDriver(configs.Browser);
            _webDriverFactory.WindowMaximize();
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriverFactory.CloseDriverAndFinishHim();
        }
    }
}
