using UI.Business.Pages;

namespace UI.Tests.MSTests.Tests
{
    [TestClass]
    public class LaunchesTest : BaseTestMSTest
    {
        [TestMethod]
        public void CompareSeveralLaunches()
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            menuPage.CLickOnLaunchesButton();
            allLaunchesPage.CheckAllLaunches();
            allLaunchesPage.ClickOnCompareButton();

            Assert.IsTrue(compareLaunchesPage.IsCompareLaunchesWindowDisplayed(), "Compare Launches Window isn't displayed");
            Assert.IsTrue(compareLaunchesPage.IsCompareLaunchesNameDisplayed(), "Compare Launches Name isn't displayed");
        }


        [TestMethod]
        public void LaunchContainsTestData()
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            menuPage.CLickOnLaunchesButton();

            Assert.IsTrue(allLaunchesPage.IsPassedValuesContainsAllLaunches(), "All Launches Contain Passed Values ");
            Assert.IsTrue(allLaunchesPage.IsTotalValuesContainsAllLaunches(), "All Launches Contain Total Values");
            Assert.IsTrue(allLaunchesPage.IsFailedValuesContainsAllLaunches(), "All Launches Contain Failed Values");
        }


        [TestMethod]
        public void DeleteLaunch()
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            menuPage.CLickOnLaunchesButton();
            var countOfLaunchesBeforeDeleting = allLaunchesPage.CountOfLaunches();
            allLaunchesPage.CheckFirstLaunch();
            allLaunchesPage.ClickOnDeleteButton();
            deleteLaunchesPage.ClickOnDeleteButtonAgain();
            var countOfLaunchesAfterDeleting = allLaunchesPage.CountOfLaunches();

            Assert.IsFalse(countOfLaunchesBeforeDeleting.Equals(countOfLaunchesAfterDeleting), "Launch isn't deleted");
        }

        [TestMethod]
        public void LaunchDetails()
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            menuPage.CLickOnLaunchesButton();
            allLaunchesPage.ClickOnFirstLaunch();

            Assert.IsTrue(launchDetailsPage.IsSuiteGroupDisplayed(), "Launch details page is not displayed");
        }
    }
}