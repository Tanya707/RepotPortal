using Core.Helpers;
using Core.Models;
using Framework.Core.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using UI.Business.Driver;

namespace Framework.Core.Tests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [TestFixture]
    public abstract class BaseTestNUnit
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
            webDriverFactory.CloseDriverAndFinishHim();
        }

    }
}
