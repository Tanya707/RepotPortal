using Core.Helpers;
using Core.Models;
using Framework.Core.Utilities;
using ReportPortal;
using UI.Business.Steps;

namespace Framework.Core.Tests
{
    [TestClass]
    public class BaseTestMSTest
    {
        private WebDriverFactory webDriverFactory;
        protected Settings settings = SettingHelper.LoadFromAppSettings();
        protected ConfigSettings configs = SettingHelper.LoadFromConfigSettings();
        protected LoginTestSteps loginPage => new LoginTestSteps(webDriverFactory.GetDriver());
        protected AllDashboardsContext allDashboardsPage => new AllDashboardsContext(webDriverFactory.GetDriver());
        protected AllLaunchesSteps allLaunchesPage => new AllLaunchesSteps(webDriverFactory.GetDriver());

        [TestInitialize]
        public void SetUp()
        {
            webDriverFactory = new WebDriverFactory();
            webDriverFactory.InitializeDriver(configs.Browser);
            webDriverFactory.WindowMaximise();
        }

        [TestCleanup]
        public void TearDown()
        {
            webDriverFactory.CloseDriverAndFinishHim();
        }

    }
}
