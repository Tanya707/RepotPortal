using Core.Helpers;
using Core.Models;
using Framework.Core.Utilities;
using NUnit.Framework;
namespace Framework.Core.Tests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [TestFixture]
    public abstract class BaseTestNUnit
    {
        protected WebDriverFactory webDriverFactory;
        protected Settings settings = SettingHelper.LoadFromAppSettings();
        protected ConfigSettings configs = SettingHelper.LoadFromConfigSettings();

        [SetUp]
        public void SetUp()
        {
            webDriverFactory = new WebDriverFactory();
            webDriverFactory.InitializeDriver(configs.Browser);
            webDriverFactory.WindowMaximise();
        }

        [TearDown]
        public void TearDown()
        {
            webDriverFactory.CloseDriverAndFinishHim();
        }

    }
}
