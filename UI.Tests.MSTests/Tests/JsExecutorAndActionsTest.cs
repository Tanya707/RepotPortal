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
            var nameFirstDashboardBeforeChangingPlaces = dashboardPage.GetDashboardNameByIndex(0);
            var nameSecondDashboardBeforeChangingPlaces = dashboardPage.GetDashboardNameByIndex(1);
            var dashboardAfterChanging = dashboardPage.ChangePlacesOfTwoTables(0, 1);
            var nameFirstDashboardAfterChangingPlaces = dashboardAfterChanging.GetDashboardNameByIndex(0);
            var nameSecondDashboardAfterChangingPlaces = dashboardAfterChanging.GetDashboardNameByIndex(1);
            Assert.IsTrue(nameFirstDashboardBeforeChangingPlaces.Equals(nameFirstDashboardAfterChangingPlaces), "The tables have not been swapped");
            Assert.IsTrue(nameSecondDashboardBeforeChangingPlaces.Equals(nameSecondDashboardAfterChangingPlaces), "The tables have not been swapped");
        }


        [TestMethod]
        public void ResizeFirstTable()
        {
            loginPage.OpenLogInPage(settings.ReportPortalUrl.LocalBaseUrl);

            loginPage.LogIn(settings.SuperadminUser.UserName, settings.SuperadminUser.Password);
            menuPage.CLickOnAllDashboardsButton();
            allDashboardsPage.ClickOnDashboardButton();
            var (heightBeforeResizing, widthBeforeResizing) = dashboardPage.GetHeightAndWidthOfFirstTable();
            dashboardPage.ResizeFirstTable(15, 15);
            var (heightAfterResizing, widthAfterResizing) = dashboardPage.GetHeightAndWidthOfFirstTable();

            Assert.IsTrue(heightBeforeResizing < heightAfterResizing, "Height of table is incorrect");
            Assert.IsTrue(widthBeforeResizing < widthAfterResizing, "Width of table is incorrect");
        }
    }
}