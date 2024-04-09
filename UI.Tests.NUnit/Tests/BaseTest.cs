using Core.Helpers;
using Core.Logger;
using Core.Models;
using Framework.Core.Pages;
using Framework.Core.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TestProject.Enums;

namespace Framework.Core.Tests
{
    public class BaseTest
    {
        protected Settings settings = SettingHelper.LoadFromAppSettings();

        [SetUp]
        public void SetUp()
        {
            WebDriverFactory.InitializeDriver(BrowserList.Chrome);
            WebDriverFactory.WindowMaximise();
        }

        [TearDown]
        public void TearDown()
        {
            WebDriverFactory.CloseDriver();
            WebDriverFactory.FinishHim();
        }

    }
}
