﻿using Core.Driver;
using Core.Helpers;
using Core.Models;
using UI.Business.Steps;

namespace UI.Tests.NUnit.Tests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    [TestFixture]
    public abstract class BaseTestNUnit
    {
        private WebDriverFactory _webDriverFactory;
        protected Settings settings = SettingHelper.LoadFromAppSettings();
        protected ConfigSettings configs = SettingHelper.LoadFromConfigSettings();
        protected LoginTestSteps loginPage => new LoginTestSteps(_webDriverFactory.GetDriver());
        protected MenuSteps menuPage => new MenuSteps(_webDriverFactory.GetDriver());
        protected AllLaunchesSteps allLaunchesPage => new AllLaunchesSteps(_webDriverFactory.GetDriver());

        [SetUp]
        public void SetUp()
        {
            _webDriverFactory = new WebDriverFactory();
            _webDriverFactory.InitializeDriver(configs.Browser);
            _webDriverFactory.WindowMaximize();
        }

        [TearDown]
        public void TearDown()
        {
            _webDriverFactory.CloseDriverAndFinishHim();
        }

    }
}
