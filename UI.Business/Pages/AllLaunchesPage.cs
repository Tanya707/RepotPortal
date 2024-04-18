using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace UI.Business.Pages
{
    public class AllLaunchesPage : BasePage
    {
        private readonly By _addFilterButton = By.XPath("//div[contains(@class,'launchFiltersToolbar__add-filter-button')]/button");
        private readonly By _launchNameField = By.XPath("//input[contains(@class,'inputConditional')]");
        private readonly By _moreButton= By.XPath("//div[contains(@class,'entitiesSelector__toggler')]");
        private readonly By _totalCheckbox = By.XPath("//span[text()='Total']");
        private readonly By _secondFilterField = By.XPath("(//input[contains(@class,'inputConditional')])[2]");
        private readonly By _passedCheckbox = By.XPath("//span[text()='Passed']");
        private readonly By _launchName = By.XPath("//div[contains(@class,'gridRow__grid-row-wrapper')]//div[contains(@class,'itemInfo__name')]//span");
        private readonly By _condition = By.XPath("(//div[contains(@class,'inputConditional__conditions-selector')])[2]");
        private readonly By _equalCondition = By.XPath("(//div[text()='Equals'])[2]");
        private readonly By _totalValues = By.XPath("//a[contains(@statuses,'PASSED,FAILED,SKIPPED,INTERRUPTED')]");
        private readonly By _passedValues = By.XPath("//a[@statuses='PASSED']");

        public AllLaunchesPage(IWebDriver driver) : base(driver) { }

        public IWebElement AddFilterButton => Driver.FindElement(_addFilterButton);
        public IWebElement LaunchNameField => Driver.FindElement(_launchNameField);
        public IWebElement MoreButton => Driver.FindElement(_moreButton);
        public IWebElement TotalCheckbox => Driver.FindElement(_totalCheckbox);
        public IWebElement SecondFilterField => Driver.FindElement(_secondFilterField);
        public IWebElement PassedCheckbox => Driver.FindElement(_passedCheckbox);
        public ReadOnlyCollection<IWebElement> launchNames => Driver.FindElements(_launchName);
        public IWebElement Condition => Driver.FindElement(_condition);
        public IWebElement EqualCondition => Driver.FindElement(_equalCondition);
        public ReadOnlyCollection<IWebElement> TotalValues => Driver.FindElements(_totalValues);
        public ReadOnlyCollection<IWebElement> PassedValues => Driver.FindElements(_passedValues);

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
