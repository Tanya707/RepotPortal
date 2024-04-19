﻿using Core.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.DefaultWaitHelpers;

namespace Core.Helpers
{
    public class Waiter
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        protected static ConfigSettings configs = SettingHelper.LoadFromConfigSettings();
        private static readonly TimeSpan ConditionTimeOutDefault = TimeSpan.FromSeconds(configs.Timeout);

        public Waiter(IWebDriver driver)
        {
            _driver = driver;
        }

        public void WaitFor(Func<bool> condition, TimeSpan conditionTimeOut = default)
        {
            _wait = new WebDriverWait(_driver, conditionTimeOut == default(TimeSpan) ? ConditionTimeOutDefault : conditionTimeOut);
            _wait.Until(_ => condition.Invoke());
        }
         public void WaitForStaleElementReferenceException(IWebElement element)
            {
            WebDriverWait wait = new WebDriverWait(_driver, ConditionTimeOutDefault);

            try
            {
                wait.Until(_driver =>
                {
                    try
                    {
                        return !element.Displayed;
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