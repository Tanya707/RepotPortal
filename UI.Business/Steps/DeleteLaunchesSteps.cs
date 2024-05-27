using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;

namespace UI.Business.Steps
{
    public class DeleteLaunchesSteps : BaseSteps
    {
        public DeleteLaunchesSteps(IWebDriver driver) : base(driver) { }

        public AllLaunchesPage ClickOnDeleteButtonAgain()
        {
            _waiter.WaitFor(() => _deleteLaunchesPage.DeleteButton.Enabled());
            _logger.LogInfo("Click on delete button");
            _deleteLaunchesPage.ClickDeleteButton();
            _waiter.WaitForElementDisappared(_allLaunchesPage.Launches.First().LaunchName);
            return _allLaunchesPage;
        }
    }
}
