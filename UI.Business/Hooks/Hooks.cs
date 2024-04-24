using Core.Helpers;
using Core.Models;
using Reqnroll;
using Core.WebDriverFactory;

namespace UI.Business.Hooks
{
    [Binding]
    public class Hooks
    {
        protected ConfigSettings configs = SettingHelper.LoadFromConfigSettings();
        readonly ScenarioContext _scenarioContext;
        protected WebDriverFactory _webDriverFactory;

        public Hooks(WebDriverFactory webDriverFactory, ScenarioContext scenarioContext)
        {
            _webDriverFactory = webDriverFactory;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void SetUp()
        {
            _webDriverFactory.InitializeDriver(configs.Browser);
            _webDriverFactory.WindowMaximize();
            var driver = _webDriverFactory.GetDriver();
            _scenarioContext.Set(driver);
        }

        [AfterScenario]
        public void TearDown()
        {
            _webDriverFactory.CloseDriverAndFinishHim();
        }
    }
}
