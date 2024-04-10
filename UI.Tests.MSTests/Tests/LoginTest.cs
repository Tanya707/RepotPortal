using Core.Helpers;
using Framework.Core.Tests;
using UI.Business.Steps;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace ReportPortal
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        private static IEnumerable<object[]> GetLaunchNameTestDataList()
        {
            IEnumerable<string> LaunchNameTestDataList() => TestDataHelper.LaunchNameTestData("UI.Tests.MSTests").LaunchName;
            IEnumerable<object[]> objectEnumerable = LaunchNameTestDataList().Select(str => new object[] { str });
            return objectEnumerable;
        }

        private static IEnumerable<object[]> GetPassedTestDataList()
        {
            IEnumerable<string> PassedTestDataList() => TestDataHelper.PassedTestData("UI.Tests.MSTests").Passed;
            IEnumerable<object[]> objectEnumerable = PassedTestDataList().Select(str => new object[] { str });
            return objectEnumerable;
        }

        private static IEnumerable<object[]> GetTotalTestDataList()
        {
            IEnumerable<string> TotalTestDataList() => TestDataHelper.TotalTestData("UI.Tests.MSTests").Total;
            IEnumerable<object[]> objectEnumerable = TotalTestDataList().Select(str => new object[] { str });
            return objectEnumerable;
        }

        [TestMethod]
        public void LogInButtonTest()
        {
            LoginTestSteps loginPage = new LoginTestSteps(webDriverFactory.GetDriver());
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            Assert.IsTrue(loginPage.CheckLogInButton());
        }

        [TestMethod]
        public void LogInTestSuperadmin()
        {
            LoginTestSteps loginPage = new LoginTestSteps(webDriverFactory.GetDriver());
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps(webDriverFactory.GetDriver());
            Assert.IsTrue(allDashboardsPage.CheckLaunchesButton());
        }

        [TestMethod]
        public void LogInTestDefaultUser()
        {
            LoginTestSteps loginPage = new LoginTestSteps(webDriverFactory.GetDriver());
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.DefaultUser.UserName, settings.DefaultUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps(webDriverFactory.GetDriver());
            Assert.IsFalse(allDashboardsPage.CheckLaunchesButton());
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
            LoginTestSteps loginPage = new LoginTestSteps(webDriverFactory.GetDriver());
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps(webDriverFactory.GetDriver());
            allDashboardsPage.CLickOnLaunchesButton();
            AllLaunchesSteps allLaunchesPage = new AllLaunchesSteps(webDriverFactory.GetDriver());
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.EnterLaunchName(launchName);
            Assert.IsTrue(allLaunchesPage.CheckLaunchNames(launchName));
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
            LoginTestSteps loginPage = new LoginTestSteps(webDriverFactory.GetDriver());
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps(webDriverFactory.GetDriver());
            allDashboardsPage.CLickOnLaunchesButton();
            AllLaunchesSteps allLaunchesPage = new AllLaunchesSteps(webDriverFactory.GetDriver());
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByTotal();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField(total.ToString());
            Assert.IsTrue(allLaunchesPage.CheckTotalValues(total.ToString()));
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
            LoginTestSteps loginPage = new LoginTestSteps(webDriverFactory.GetDriver());
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps(webDriverFactory.GetDriver());
            allDashboardsPage.CLickOnLaunchesButton();
            AllLaunchesSteps allLaunchesPage = new AllLaunchesSteps(webDriverFactory.GetDriver());
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByPassed();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField(passed.ToString());
            Assert.IsTrue(allLaunchesPage.CheckPassedValues(passed.ToString()));
        }

        [TestMethod]
        [DataTestMethod]
        [DynamicData(nameof(GetLaunchNameTestDataList), DynamicDataSourceType.Method)]
        public void FilterByLaunchNameQuery(string launchName)
        {
            LoginTestSteps loginPage = new LoginTestSteps(webDriverFactory.GetDriver());
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps(webDriverFactory.GetDriver());
            allDashboardsPage.CLickOnLaunchesButton();
            AllLaunchesSteps allLaunchesPage = new AllLaunchesSteps(webDriverFactory.GetDriver());
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.EnterLaunchName(launchName);
            Assert.IsTrue(allLaunchesPage.CheckLaunchNames(launchName));
        }

        [TestMethod]
        [DataTestMethod]
        [DynamicData(nameof(GetPassedTestDataList), DynamicDataSourceType.Method)]
        public void FilterByPassedQuery(string passed)
        {
            LoginTestSteps loginPage = new LoginTestSteps(webDriverFactory.GetDriver());
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps(webDriverFactory.GetDriver());
            allDashboardsPage.CLickOnLaunchesButton();
            AllLaunchesSteps allLaunchesPage = new AllLaunchesSteps(webDriverFactory.GetDriver());
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByPassed();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField(passed);
            Assert.IsTrue(allLaunchesPage.CheckPassedValues(passed));
        }

        [TestMethod]
        [DataTestMethod]
        [DynamicData(nameof(GetTotalTestDataList), DynamicDataSourceType.Method)]
        public void FilterByTotalQuery(string total)
        {
            LoginTestSteps loginPage = new LoginTestSteps(webDriverFactory.GetDriver());
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps(webDriverFactory.GetDriver());
            allDashboardsPage.CLickOnLaunchesButton();
            AllLaunchesSteps allLaunchesPage = new AllLaunchesSteps(webDriverFactory.GetDriver());
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByTotal();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField(total);
            Assert.IsTrue(allLaunchesPage.CheckTotalValues(total));
        }
    }
}