using Core.Helpers;
using Framework.Core.Tests;
using UI.Business.Steps;
namespace ReportPortal
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LoginTest : BaseTest
    {

        public static IEnumerable<string> TotalTestDataList() => TestDataHelper.TotalTestData().Total;
        public static IEnumerable<string> PassedTestDataList() => TestDataHelper.PassedTestData().Passed;
        public static IEnumerable<string> LaunchNameTestDataList() => TestDataHelper.LaunchNameTestData().LaunchName;

        [Test]
        public void LogInButtonDisplayedTest()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            Assert.IsTrue(loginPage.CheckLogInButton());
        }

        [Test]
        public void PasswordFieldDisplayedTest()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            Assert.True(loginPage.CheckPasswordField());
        }

        [Test]
        public void LogInFieldDisplayedTest()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            Assert.True(loginPage.CheckLogInButton());
        }

        [Test]
        public void LogInTestSuperadmin()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps();
            Assert.IsTrue(allDashboardsPage.CheckLaunchesButton());
        }


        [Test]
        public void LogInTestDefault()
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.DefaultUser.UserName, settings.DefaultUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps();
            Assert.IsFalse(allDashboardsPage.CheckLaunchesButton());
        }

        [TestCase("Demo Api Tests")]
        [TestCase("Demo Api")]
        [TestCase("Api Tests")]
        [TestCase("Tests")]
        [TestCase("Demo")]
        [NonParallelizable]
        public void FilterByLaunchName(string launchName)
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps();
            allDashboardsPage.CLickOnLaunchesButton();
            AllLaunchesSteps allLaunchesPage = new AllLaunchesSteps();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.EnterLaunchName(launchName);
            Assert.IsTrue(allLaunchesPage.CheckLaunchNames(launchName));
        }

        [TestCase(10)]
        [TestCase(15)]
        [TestCase(20)]
        [TestCase(25)]
        [TestCase(30)]
        [NonParallelizable]
        public void FilterByTotal(int total)
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps();
            allDashboardsPage.CLickOnLaunchesButton();
            AllLaunchesSteps allLaunchesPage = new AllLaunchesSteps();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByTotal();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField(total.ToString());
            Assert.IsTrue(allLaunchesPage.CheckTotalValues(total.ToString()));
        }

        [TestCase(10)]
        [TestCase(5)]
        [TestCase(20)]
        [TestCase(1)]
        [TestCase(30)]
        [NonParallelizable]
        public void FilterByPassed(int passed)
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps();
            allDashboardsPage.CLickOnLaunchesButton();
            AllLaunchesSteps allLaunchesPage = new AllLaunchesSteps();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByPassed();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField(passed.ToString());
            Assert.IsTrue(allLaunchesPage.CheckPassedValues(passed.ToString()));
        }

        [TestCaseSource(nameof(TotalTestDataList))]
        [NonParallelizable]
        public void FilterByTotalQuery(string total)
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps();
            allDashboardsPage.CLickOnLaunchesButton();
            AllLaunchesSteps allLaunchesPage = new AllLaunchesSteps();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByTotal();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField(total);
            Assert.IsTrue(allLaunchesPage.CheckTotalValues(total));
        }

        [TestCaseSource(nameof(PassedTestDataList))]
        [NonParallelizable]
        public void FilterByPassedQuery(string passed)
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps();
            allDashboardsPage.CLickOnLaunchesButton();
            AllLaunchesSteps allLaunchesPage = new AllLaunchesSteps();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByPassed();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField(passed);
            Assert.IsTrue(allLaunchesPage.CheckPassedValues(passed));
        }

        [TestCaseSource(nameof(LaunchNameTestDataList))]
        [NonParallelizable]
        public void FilterByLaunchNameQuery(string launchName)
        {
            LoginTestSteps loginPage = new LoginTestSteps();
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);
            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps();
            allDashboardsPage.CLickOnLaunchesButton();
            AllLaunchesSteps allLaunchesPage = new AllLaunchesSteps();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.EnterLaunchName(launchName);
            Assert.IsTrue(allLaunchesPage.CheckLaunchNames(launchName));
        }
    }
}