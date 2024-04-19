using Core.Helpers;
using Core.Models;
using Framework.Core.Tests;
using OpenQA.Selenium;
using UI.Business.Pages;
using UI.Business.Steps;
namespace ReportPortal
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LoginTest : BaseTestNUnit
    {
        public static IEnumerable<string> TotalTestDataList() => TestDataHelper.TestData("UI.Tests.NUnit").Total;
        public static IEnumerable<string> PassedTestDataList() => TestDataHelper.TestData("UI.Tests.NUnit").Passed;
        public static IEnumerable<string> LaunchNameTestDataList() => TestDataHelper.TestData("UI.Tests.NUnit").LaunchName;

        [Test]
        public void LogInButtonDisplayedTest()
        {
            LoginTestSteps loginPage = new LoginTestSteps(webDriverFactory.GetDriver());
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            Assert.IsTrue(loginPage.IsLogInButtonDisplayed(), "Log in button isn't dispalyed");
        }

        [Test]
        public void PasswordFieldDisplayedTest()
        {
            LoginTestSteps loginPage = new LoginTestSteps(webDriverFactory.GetDriver());
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            Assert.True(loginPage.IsPasswordFieldDisplayed(), "Password field isn't dispalyed");
        }

        [Test]
        public void LogInFieldDisplayedTest()
        {
            LoginTestSteps loginPage = new LoginTestSteps(webDriverFactory.GetDriver());
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            Assert.True(loginPage.IsLogInButtonDisplayed(), "Log in field isn't dispalyed");
        }

        [Test]
        public void LogInTestSuperadmin()
        {
            LoginTestSteps loginPage = new LoginTestSteps(webDriverFactory.GetDriver());
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps(webDriverFactory.GetDriver());

            Assert.IsTrue(allDashboardsPage.IsLaunchesButtonDisplayed(), "Launches button isn't dispalyed after log in as superadmin");
        }


        [Test]
        public void LogInTestDefault()
        {
            LoginTestSteps loginPage = new LoginTestSteps(webDriverFactory.GetDriver());
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.DefaultUser.UserName, settings.DefaultUser.Password);
            AllDashboardsSteps allDashboardsPage = new AllDashboardsSteps(webDriverFactory.GetDriver());

            Assert.IsFalse(allDashboardsPage.IsLaunchesButtonDisplayed(), "Launches button isn't dispalyed after log in as default user");
        }

        [TestCase("Demo Api Tests")]
        [TestCase("Demo Api")]
        [TestCase("Api Tests")]
        [TestCase("Tests")]
        [TestCase("Demo")]
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

            Assert.IsTrue(allLaunchesPage.CheckTotalValue(launchName), "Total value isn't correct after filtering");
        }

        [TestCase(10)]
        [TestCase(15)]
        [TestCase(20)]
        [TestCase(25)]
        [TestCase(30)]
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

            Assert.IsTrue(allLaunchesPage.CheckTotalValue(total.ToString()), "Total value isn't correct after filtering");
        }

        [TestCase(10)]
        [TestCase(5)]
        [TestCase(20)]
        [TestCase(1)]
        [TestCase(30)]
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

            Assert.IsTrue(allLaunchesPage.CheckPassedValue(passed.ToString()), "Passed value isn't correct after filtering");
        }

        [TestCaseSource(nameof(TotalTestDataList))]
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

            Assert.IsTrue(allLaunchesPage.CheckTotalValue(total), "Total value isn't correct after filtering");
        }

        [TestCaseSource(nameof(PassedTestDataList))]
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

            Assert.IsTrue(allLaunchesPage.CheckPassedValue(passed), "Passed value isn't correct after filtering");
        }

        [TestCaseSource(nameof(LaunchNameTestDataList))]
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

            Assert.IsTrue(allLaunchesPage.CheckLaunchName(launchName), "Launch Name isn't correct after filtering");
        }
    }
}