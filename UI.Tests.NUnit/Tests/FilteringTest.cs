using Core.Helpers;

namespace UI.Tests.NUnit.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]

    public class FilteringTest : BaseTestNUnit
    {
        public static IEnumerable<string> TotalTestDataList() => TestDataHelper.TestData("UI.Tests.NUnit").Total;
        public static IEnumerable<string> PassedTestDataList() => TestDataHelper.TestData("UI.Tests.NUnit").Passed;
        public static IEnumerable<string> LaunchNameTestDataList() => TestDataHelper.TestData("UI.Tests.NUnit").LaunchName;

        [TestCase("Demo Api Tests")]
        [TestCase("Demo Api")]
        [TestCase("Api Tests")]
        [TestCase("Tests")]
        [TestCase("Demo")]
        public void FilterByLaunchName(string launchName)
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            menuPage.CLickOnLaunchesButton();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.EnterLaunchName(launchName);

            Assert.IsTrue(allLaunchesPage.CheckLaunchName(launchName), "Launch name isn't correct after filtering");
        }

        [TestCase(10)]
        [TestCase(15)]
        [TestCase(20)]
        [TestCase(25)]
        [TestCase(30)]
        public void FilterByTotal(int total)
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            menuPage.CLickOnLaunchesButton();
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
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            menuPage.CLickOnLaunchesButton();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByPassed();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField(passed.ToString());

            Assert.IsTrue(allLaunchesPage.CheckPassedValue(passed.ToString()), "Passed value isn't correct after filtering");
        }

        [TestCaseSource(nameof(TotalTestDataList))]
        public void FilterByTotalQuery(string total)
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            menuPage.CLickOnLaunchesButton();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByTotal();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField(total);

            Assert.IsTrue(allLaunchesPage.CheckTotalValue(total), "Total value isn't correct after filtering");
        }

        [TestCaseSource(nameof(PassedTestDataList))]
        public void FilterByPassedQuery(string passed)
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            menuPage.CLickOnLaunchesButton();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.ChooseFilterByPassed();
            allLaunchesPage.SelectEqual();
            allLaunchesPage.EnterSecondFilterField(passed);

            Assert.IsTrue(allLaunchesPage.CheckPassedValue(passed), "Passed value isn't correct after filtering");
        }

        [TestCaseSource(nameof(LaunchNameTestDataList))]
        public void FilterByLaunchNameQuery(string launchName)
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            menuPage.CLickOnLaunchesButton();
            allLaunchesPage.ClickOnFilterByButton();
            allLaunchesPage.EnterLaunchName(launchName);

            Assert.IsTrue(allLaunchesPage.CheckLaunchName(launchName), "Launch Name isn't correct after filtering");
        }
    }
}