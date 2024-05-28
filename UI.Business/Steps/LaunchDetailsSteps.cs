﻿using Core.Logger;
using OpenQA.Selenium;
using UI.Business.Pages;

namespace UI.Business.Steps
{
    public class LaunchDetailsSteps : BaseSteps
    {
        public LaunchDetailsSteps(IWebDriver driver) : base(driver) { }


        public bool IsSuiteGroupDisplayed()
        {
            _waiter.WaitFor(() => _launchDetailsPage.SuiteGroup.Displayed());
            return _launchDetailsPage.SuiteGroup.Displayed();
        }
    }
}
