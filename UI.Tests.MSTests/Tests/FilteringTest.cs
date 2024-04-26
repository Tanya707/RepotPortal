using Core.Helpers;

namespace UI.Tests.MSTests.Tests
{
    [TestClass]
    public class FilteringTest : BaseTestMSTest
    {
        private static IEnumerable<object[]> GetLaunchNameTestDataList()
        {
            IEnumerable<string> LaunchNameTestDataList() => TestDataHelper.TestData("UI.Tests.MSTests").LaunchName;
            IEnumerable<object[]> objectEnumerable = LaunchNameTestDataList().Select(str => new object[] { str });
            return objectEnumerable;
        }

        private static IEnumerable<object[]> GetPassedTestDataList()
        {
            IEnumerable<string> PassedTestDataList() => TestDataHelper.TestData("UI.Tests.MSTests").Passed;
            IEnumerable<object[]> objectEnumerable = PassedTestDataList().Select(str => new object[] { str });
            return objectEnumerable;
        }

        private static IEnumerable<object[]> GetTotalTestDataList()
        {
            IEnumerable<string> TotalTestDataList() => TestDataHelper.TestData("UI.Tests.MSTests").Total;
            IEnumerable<object[]> objectEnumerable = TotalTestDataList().Select(str => new object[] { str });
            return objectEnumerable;
        }

        [TestMethod]
        [DataRow("Demo Api Tests")]
        [DataRow("Demo Api")]
        [DataRow("Api Tests")]
        [DataRow("Tests")]
        [DataRow("Demo")]
        [DoNotParallelize]
        public void FilterByLaunchName(string launchName)
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            allDashboardsPage.CLickOnLaunchesButton();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.EnterLaunchName(launchName);

            Assert.IsTrue(allLaunchesPage.CheckLaunchName(launchName), "Launch Name isn't correct after filtering");
        }

        [TestMethod]
        [DataRow(10)]
        [DataRow(15)]
        [DataRow(20)]
        [DataRow(25)]
        [DataRow(30)]
        [DoNotParallelize]
        public void FilterByTotal(int total)
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            allDashboardsPage.CLickOnLaunchesButton();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByTotal();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField(total.ToString());

            Assert.IsTrue(allLaunchesPage.CheckTotalValue(total.ToString()), "Total value isn't correct after filtering");
        }

        [TestMethod]
        [DataRow(10)]
        [DataRow(5)]
        [DataRow(20)]
        [DataRow(1)]
        [DataRow(30)]
        [DoNotParallelize]
        public void FilterByPassed(int passed)
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            allDashboardsPage.CLickOnLaunchesButton();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByPassed();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField(passed.ToString());

            Assert.IsTrue(allLaunchesPage.CheckPassedValue(passed.ToString()), "Passed value isn't correct after filtering");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetLaunchNameTestDataList), DynamicDataSourceType.Method)]
        public void FilterByLaunchNameQuery(string launchName)
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            allDashboardsPage.CLickOnLaunchesButton();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.EnterLaunchName(launchName);

            Assert.IsTrue(allLaunchesPage.CheckLaunchName(launchName), "Launch Name isn't correct after filtering");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetPassedTestDataList), DynamicDataSourceType.Method)]
        public void FilterByPassedQuery(string passed)
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            allDashboardsPage.CLickOnLaunchesButton();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByPassed();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField(passed);

            Assert.IsTrue(allLaunchesPage.CheckPassedValue(passed), "Passed value isn't correct after filtering");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetTotalTestDataList), DynamicDataSourceType.Method)]
        public void FilterByTotalQuery(string total)
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            allDashboardsPage.CLickOnLaunchesButton();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByTotal();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField(total);

            Assert.IsTrue(allLaunchesPage.CheckTotalValue(total), "Total value isn't correct after filtering");
        }
    }
}