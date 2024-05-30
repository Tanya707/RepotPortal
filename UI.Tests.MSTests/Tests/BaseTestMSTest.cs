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
        protected MenuSteps menuPage => new MenuSteps(_webDriverFactory.GetDriver());
        protected AllLaunchesSteps allLaunchesPage => new AllLaunchesSteps(_webDriverFactory.GetDriver());
        protected AllDashboardsSteps allDashboardsPage=> new AllDashboardsSteps(_webDriverFactory.GetDriver());
        protected DashboardSteps dashboardPage => new DashboardSteps(_webDriverFactory.GetDriver());
        protected CompareLaunchesSteps compareLaunchesPage => new CompareLaunchesSteps(_webDriverFactory.GetDriver());
        protected DeleteLaunchesSteps deleteLaunchesPage => new DeleteLaunchesSteps(_webDriverFactory.GetDriver());
        protected LaunchDetailsSteps launchDetailsPage => new LaunchDetailsSteps(_webDriverFactory.GetDriver());
        protected readonly SlackService slackService = new SlackService();

        [TestInitialize]
        public void SetUp()
        {
            _webDriverFactory = new WebDriverFactory();
            _webDriverFactory.InitializeDriver(configs.Browser);
            _webDriverFactory.WindowMaximize();
            slackService.PostNotification("Test has been started");
        }

        [TestCleanup]
        public void TearDown()
        {
            _webDriverFactory.CloseDriverAndFinishHim();
            slackService.PostNotification("Test has been finished");
        }
    }
}
