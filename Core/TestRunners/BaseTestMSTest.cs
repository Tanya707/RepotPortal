using Core.Helpers;
using Core.Models;
using Framework.Core.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using UI.Business.Driver;

namespace Framework.Core.Tests
{
    [TestClass]
    public class BaseTestMSTest
    {
        protected WebDriverFactory webDriverFactory;
        protected Settings settings = SettingHelper.LoadFromAppSettings();
        protected ConfigSettings configs = SettingHelper.LoadFromConfigSettings();

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
