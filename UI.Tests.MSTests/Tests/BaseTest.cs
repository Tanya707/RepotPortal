using Core.Helpers;
using Core.Logger;
using Core.Models;
using Framework.Core.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Enums;

namespace Framework.Core.Tests
{
    public class BaseTest
    {

        protected Settings settings = SettingHelper.LoadFromAppSettings();

        [TestInitialize]
        public void SetUp()
        {
            WebDriverFactory.InitializeDriver(BrowserList.Chrome);
            WebDriverFactory.WindowMaximise();
        }

        [TestCleanup]
        public void TearDown()
        {
            WebDriverFactory.CloseDriver();
            WebDriverFactory.FinishHim();
        }

    }
}
