using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Business.Pages
{
    public class AllLaunchesPage : BasePage
    {
        private readonly By addFilterButton = By.XPath("//div[contains(@class,'launchFiltersToolbar__add-filter-button')]/button");
        private readonly By launchNameField = By.XPath("//input[contains(@class,'inputConditional')]");
        private readonly By moreButton= By.XPath("//div[contains(@class,'entitiesSelector__toggler')]");
        private readonly By totalCheckbox = By.XPath("//span[text()='Total']");
        private readonly By secondFilterField = By.XPath("(//input[contains(@class,'inputConditional')])[2]");
        private readonly By passedCheckbox = By.XPath("//span[text()='Passed']");
        private readonly By launchName = By.XPath("//div[contains(@class,'gridRow__grid-row-wrapper')]//div[contains(@class,'itemInfo__name')]//span");
        private readonly By condition = By.XPath("(//div[contains(@class,'inputConditional__conditions-selector')])[2]");
        private readonly By equalCondition = By.XPath("(//div[text()='Equals'])[2]");
        private readonly By totalValues = By.XPath("//a[contains(@statuses,'PASSED,FAILED,SKIPPED,INTERRUPTED')]");
        private readonly By passedValues = By.XPath("//a[@statuses='PASSED']");


        public IWebElement AddFilterButton => Driver.FindElement(addFilterButton);
        public IWebElement LaunchNameField => Driver.FindElement(launchNameField);
        public IWebElement MoreButton => Driver.FindElement(moreButton);
        public IWebElement TotalCheckbox => Driver.FindElement(totalCheckbox);
        public IWebElement SecondFilterField => Driver.FindElement(secondFilterField);
        public IWebElement PassedCheckbox => Driver.FindElement(passedCheckbox);
        public ReadOnlyCollection<IWebElement> launchNames => Driver.FindElements(launchName);
        public IWebElement Condition => Driver.FindElement(condition);
        public IWebElement EqualCondition => Driver.FindElement(equalCondition);
        public ReadOnlyCollection<IWebElement> TotalValues => Driver.FindElements(totalValues);
        public ReadOnlyCollection<IWebElement> PassedValues => Driver.FindElements(passedValues);

        public void ClickAddFilterButton() => AddFilterButton.Click();
        public void ClickMoreButton() => MoreButton.Click();
        public void ClickTotalCheckbox() => TotalCheckbox.Click();
        public void ClickPassedCheckbox() => PassedCheckbox.Click();
        public void EnterLaunchName(string launchName) => LaunchNameField.SendKeys(launchName);
        public void EnterSecondFilterField(string value) => SecondFilterField.SendKeys(value);
        public void ClickCondition() => Condition.Click();
        public void ClickEqualCondition() => EqualCondition.Click();
    }
}
