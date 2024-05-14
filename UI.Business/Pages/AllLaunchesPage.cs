using Core.Driver;
using Core.Elements;
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
        private readonly By _pageSizeButton = By.XPath("//*[contains(@class, 'pageSizeControl__size-text')]");

        public AllLaunchesPage(IWebDriver driver) : base(driver) { }

        public Button AddFilterButton => Driver.FindElement<Button>(_addFilterButton);
        public TextField LaunchNameField => Driver.FindElement<TextField>(_launchNameField);
        public Button MoreButton => Driver.FindElement<Button>(_moreButton);
        public Checkbox TotalCheckbox => Driver.FindElement<Checkbox>(_totalCheckbox);
        public TextField SecondFilterField => Driver.FindElement<TextField>(_secondFilterField);
        public Checkbox PassedCheckbox => Driver.FindElement<Checkbox>(_passedCheckbox);
        public ReadOnlyCollection<BasicElement> LaunchNames => Driver.FindElements<BasicElement>(_launchName);
        public Button Condition => Driver.FindElement<Button>(_condition);
        public Button EqualCondition => Driver.FindElement<Button>(_equalCondition);
        public Button ActionsButton => Driver.FindElement<Button>(_actionsButton);
        public ReadOnlyCollection<BasicElement> TotalValues => Driver.FindElements<BasicElement>(_totalValues);
        public ReadOnlyCollection<BasicElement> PassedValues => Driver.FindElements<BasicElement>(_passedValues);
        public Button PageSizeButton => Driver.FindElement<Button>(_pageSizeButton);

        public void ClickAddFilterButton() => AddFilterButton.Click();
        public void ClickMoreButton() => MoreButton.Click();
        public void ClickTotalCheckbox() => TotalCheckbox.Check();
        public void ClickPassedCheckbox() => PassedCheckbox.Check();
        public void EnterLaunchName(string launchName) => LaunchNameField.EnterText(launchName);
        public void EnterSecondFilterField(string value) => SecondFilterField.EnterText(value);
        public void ClickCondition() => Condition.Click();
        public void ClickEqualCondition() => EqualCondition.Click();
        public void ScrollPageSizeButtonIntoView() => Driver.ScrollToElementJS(PageSizeButton.Element);

        public bool IsPageSizeButtonScrolledIntoView() => Driver.IsElementScrolledIntoViewJS(PageSizeButton.Element);

        //    public void aadf()
        //    {
        //        Actions actions = new Actions(Driver);
        //        actions.DragAndDrop()
        //}

    }
}
