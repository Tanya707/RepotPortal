using Core.Helpers;
using Core.Models;
using Framework.Core.Utilities;
using OpenQA.Selenium;
using UI.Business.Driver;

namespace Framework.Core.Tests
{
    [TestClass]
    public class BaseTest
    {
        public IWebDriver driver;
        protected WebDriverFactory webDriverFactory;
        protected Settings settings = SettingHelper.LoadFromAppSettings();


        [TestInitialize]
        public void SetUp()
        {
            webDriverFactory = new WebDriverFactory();
            driver = webDriverFactory.InitializeDriver(BrowserList.Chrome);
            webDriverFactory.WindowMaximise();
        }

        [TestCleanup]
        public void TearDown()
        {
            webDriverFactory.CloseDriver();
            webDriverFactory.FinishHim();
            driver.Dispose();
        }

    }
}
