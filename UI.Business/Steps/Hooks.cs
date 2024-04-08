using Framework.Core.Utilities;
using OpenQA.Selenium;
using Reqnroll;
using TestProject.Enums;

namespace Framework.Core.Tests
{
    [Binding]
    public class Hooks
    {
        public IWebDriver Driver;

        [BeforeTestRun]
        public void SetUp(FeatureContext featureContext)
        {
            WebDriverFactory.InitializeDriver(BrowserList.Chrome)
                .Manage().Window.Maximize();
        }

        [AfterTestRun]
        public void TearDown(FeatureContext featureContext)
        {
            WebDriverFactory.CloseDriver();
        }

    }
}
