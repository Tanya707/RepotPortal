using Core.Helpers;
using Core.Models;
using Framework.Core.Utilities;
using TestProject.Enums;

namespace Framework.Core.Tests
{
    public class BaseTest
    {

        protected Settings settings = SettingHelper.LoadFromAppSettings();

        [TestInitialize]
        public void SetUp()
        {
            new WebDriverFactory().InitializeDriver(BrowserList.Chrome);
            new WebDriverFactory().WindowMaximise();
        }

        [TestCleanup]
        public void TearDown()
        {
            new WebDriverFactory().CloseDriver();
            new WebDriverFactory().FinishHim();
        }

    }
}
