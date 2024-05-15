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
            var nameDashboardBeforeChangingPlaces = dashboardPage.GetDashboardNameByIndex(0);
            dashboardPage.ChangePlacesOfTwoTables(0, 1);
            var nameDashboardAfterChangingPlaces = dashboardPage.GetDashboardNameByIndex(0);
            Assert.IsFalse(nameDashboardBeforeChangingPlaces.Equals(nameDashboardAfterChangingPlaces), "The tables have not been swapped");
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

            Assert.IsFalse(heightBeforeResizing.Equals(heightAfterResizing), "Height of table is incorrect");
            Assert.IsFalse(widthBeforeResizing.Equals(widthAfterResizing), "Width of table is incorrect");
        }
    }
}