using Framework.Core.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Framework.Core.Tests
{
    [Binding]
    public class Hooks
    {
        public IWebDriver Driver;

        [BeforeTestRun]
        public void SetUp(FeatureContext featureContext)
        {
            Browser.WindowMaximise();
        }

        [AfterTestRun]
        public void TearDown(FeatureContext featureContext)
        {
            Browser.Quit();
        }

    }
}
