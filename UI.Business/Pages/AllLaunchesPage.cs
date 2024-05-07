using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace UI.Business.Pages
{
    public class AllLaunchesPage : BasePage
    {
        private readonly By _addFilterButton = By.XPath("//*[contains(@class,'launchFiltersToolbar__add-filter-button')]/button");
        private readonly By _launchNameField = By.XPath("//*[@placeholder = 'Enter name']");
        private readonly By _moreButton= By.XPath("//*[contains(@class,'entitiesSelector__toggler')]");
        private readonly By _totalCheckbox = By.XPath("//*[contains(@class,'inputCheckbox') and text()='Total']");
        private readonly By _secondFilterField = By.XPath("//*[@placeholder = 'Enter quantity']");
        private readonly By _passedCheckbox = By.XPath("//*[contains(@class,'inputCheckbox') and text()='Passed']");
        private readonly By _launchName = By.XPath("//*[contains(@class, 'itemInfo__name-link')]/*[contains(@class,'tooltip__tooltip-trigger')]");
        private readonly By _condition = By.XPath("//*[@placeholder = 'Enter quantity']/following-sibling::*[contains(@class,'inputConditional__conditions-block')]");
        private readonly By _equalCondition = By.XPath("//*[@placeholder = 'Enter quantity']/following-sibling::*[contains(@class,'inputConditional__conditions-block')]//*[text()='Equals']");
        private readonly By _totalValues = By.XPath("//*[contains(@statuses,'PASSED,FAILED,SKIPPED,INTERRUPTED')]");
        private readonly By _passedValues = By.XPath("//*[@statuses='PASSED']");
        private readonly By _actionsButton = By.XPath("//*[./span[contains(text(),'Actions')]]");

        public AllLaunchesPage(IWebDriver driver) : base(driver) { }

        public IWebElement AddFilterButton => Driver.FindElement(_addFilterButton);
        public IWebElement LaunchNameField => Driver.FindElement(_launchNameField);
        public IWebElement MoreButton => Driver.FindElement(_moreButton);
        public IWebElement TotalCheckbox => Driver.FindElement(_totalCheckbox);
        public IWebElement SecondFilterField => Driver.FindElement(_secondFilterField);
        public IWebElement PassedCheckbox => Driver.FindElement(_passedCheckbox);
        public ReadOnlyCollection<IWebElement> LaunchNames => Driver.FindElements(_launchName);
        public IWebElement Condition => Driver.FindElement(_condition);
        public IWebElement EqualCondition => Driver.FindElement(_equalCondition);
        public IWebElement ActionsButton => Driver.FindElement(_actionsButton);
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

        public bool IsActionsDisabled()
        {
            return ActionsButton.GetAttribute("class").Contains("disabled");
        }
    }
}
