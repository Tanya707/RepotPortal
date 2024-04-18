using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.Helpers
{
    public class Waiter
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private static readonly TimeSpan ConditionTimeOutDefault = TimeSpan.FromSeconds(10);

        public Waiter(IWebDriver driver)
        {
            _driver = driver;
        }

        public void WaitFor(Func<bool> condition, TimeSpan conditionTimeOut = default)
        {
            _wait = new WebDriverWait(_driver, conditionTimeOut == default(TimeSpan) ? ConditionTimeOutDefault : conditionTimeOut);
            _wait.Until(_ => condition.Invoke());
        }
    }
}
