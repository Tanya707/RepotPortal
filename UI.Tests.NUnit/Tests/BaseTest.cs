using Core.Helpers;
using Core.Models;
using Framework.Core.Utilities;
using OpenQA.Selenium;
using UI.Business.Driver;

namespace Framework.Core.Tests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [TestFixture]
    public abstract class BaseTest
    {
        protected WebDriverFactory webDriverFactory;
        protected Settings settings = SettingHelper.LoadFromAppSettings();

        [SetUp]
        public void SetUp()
        {
            webDriverFactory = new WebDriverFactory();
            webDriverFactory.InitializeDriver(BrowserList.Chrome);
            webDriverFactory.WindowMaximise();
        }

        [TearDown]
        public void TearDown()
        {
            webDriverFactory.CloseDriver();
            webDriverFactory.FinishHim();
        }

    }
}
