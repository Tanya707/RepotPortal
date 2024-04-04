using Core.Logger;
using Framework.Core.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Tests
{
    public class BaseTest
    {
        public IWebDriver Driver;

        [TestInitialize]
        public void SetUp()
        {
            Browser.WindowMaximise();
        }

        public void OpenMainPage(string url)
        {
            Browser.NavigateTo(url);
        }

        [TestCleanup]
        public void TearDown()
        {
            Browser.Quit();
        }

    }
}
