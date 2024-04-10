using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.Helpers
{
    public class Waiter
    {
        private IWebDriver Driver;
        private WebDriverWait wait;
        private static readonly TimeSpan ConditionTimeOutDefault = TimeSpan.FromSeconds(10);

        public Waiter(IWebDriver driver)
        {
            Driver = driver;
        }

        public void WaitFor(Func<bool> condition, TimeSpan conditionTimeOut = default)
        {
            wait = new WebDriverWait(Driver, conditionTimeOut == default(TimeSpan) ? ConditionTimeOutDefault : conditionTimeOut);
            wait.Until(_ => condition.Invoke());
        }
    }
}
