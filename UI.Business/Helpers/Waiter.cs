using OpenQA.Selenium;


using Framework.Core.Utilities;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Core.Helpers
{
    public static class Waiter
    {
        private static IWebDriver Driver => WebDriverFactory.GetDriver();
        private static WebDriverWait wait;
        private static readonly TimeSpan ConditionTimeOutDefault = TimeSpan.FromSeconds(10);

        public static void WaitFor(Func<bool> condition, TimeSpan conditionTimeOut = default)
        {
            wait = new WebDriverWait(Driver, conditionTimeOut == default(TimeSpan) ? ConditionTimeOutDefault : conditionTimeOut);
            wait.Until(_ => condition.Invoke());
        }
    }
}
