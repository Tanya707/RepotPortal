using Core.Logger;
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
