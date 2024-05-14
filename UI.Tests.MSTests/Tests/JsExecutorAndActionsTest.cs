namespace UI.Tests.MSTests.Tests
{
    [TestClass]
    public class JsExecutorAndActionsTest : BaseTestMSTest
    {
        [TestMethod]
        public void AmountPerPageIsDisplayed()
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            menuPage.CLickOnLaunchesButtonJS();
            allLaunchesPage.ScrollPageSizeButtonIntoView();

            Assert.IsTrue(allLaunchesPage.IsPageSizeButtonScrolledIntoView(), "Page Size Button isn't Into View");
        }

        [TestMethod]
        public void ChangePlacesOfTwoTables()
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            menuPage.CLickOnAllDashboardsButton();
            allDashboardsPage.ClickOnDashboardButton();
            dashboardPage.ChangePlacesOfTwoTables(1, 2);
            Thread.Sleep(50000);

            //Assert.IsTrue(allDashboardsPage.IsLaunchesButtonDisplayed(), "Launches button isn't dispalyed after log in as superadmin");
        }

    }
}