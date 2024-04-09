using Core.Helpers;
using Core.Models;
using Framework.Core.Utilities;
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
