using Core.Elements;
using Core.Helpers;
using Core.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.Driver
{
    public class WebDriverWaiter
    {
        private IWebDriver _driver;
        protected static ConfigSettings configs = SettingHelper.LoadFromConfigSettings();
        private static readonly TimeSpan ConditionTimeOutDefault = TimeSpan.FromSeconds(configs.Timeout);
        private static readonly TimeSpan PollingInterval = TimeSpan.FromSeconds(configs.PollingInterval);

        public WebDriverWaiter(IWebDriver driver)
        {
            _driver = driver;
        }

        public void WaitFor(Func<bool> condition, TimeSpan conditionTimeOut = default)
        {
            WebDriverWait wait = new WebDriverWait(_driver, conditionTimeOut == default ? ConditionTimeOutDefault : conditionTimeOut);
            wait.Until(_ => condition.Invoke());
        }
        public void WaitForStaleElementReferenceException(IBasicElement element)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(_driver);
            fluentWait.Timeout = ConditionTimeOutDefault;
            fluentWait.PollingInterval = PollingInterval;
            try
            {
                fluentWait.Until(_driver =>
                {
                    try
                    {
                        return !element.Displayed();
                    }
                    catch (NoSuchElementException)
                    {
                        return true;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return true;
                    }
                });
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException($"Timed out waiting for stale element reference exception for element located by: {element}");
            }
        }
    }
}
