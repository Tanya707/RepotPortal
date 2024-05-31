using OpenQA.Selenium;

namespace UI.Business.Steps
{
    public class CompareLaunchesSteps : BaseSteps
    {
        public CompareLaunchesSteps(IWebDriver driver) : base(driver) { }


        public bool IsCompareLaunchesNameDisplayed()
        {
            _waiter.WaitFor(() => _compareLaunchesPage.CompareLaunchesName.Displayed());
            return _compareLaunchesPage.CompareLaunchesName.Displayed();
        }

        public bool IsCompareLaunchesWindowDisplayed()
        {
            _waiter.WaitFor(() => _compareLaunchesPage.CompareLaunchesWindow.Displayed());
            return _compareLaunchesPage.CompareLaunchesWindow.Displayed();
        }
    }
}
