using Core.Driver;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using Core.Elements;
using UI.Business.CustomElements;
using UI.Business.Components;

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
        private readonly By _condition = By.XPath("//*[@placeholder = 'Enter quantity']/following-sibling::*[contains(@class,'inputConditional__conditions-block')]");
        private readonly By _equalCondition = By.XPath("//*[@placeholder = 'Enter quantity']/following-sibling::*[contains(@class,'inputConditional__conditions-block')]//*[text()='Equals']");
        private readonly By _actionsButton = By.XPath("//*[./span[contains(text(),'Actions')]]");
        private readonly By _pageSizeButton = By.XPath("//*[contains(@class, 'pageSizeControl__size-text')]");
        private readonly By _compareButton = By.XPath("//*[contains(text(),'Compare')]");
        private readonly By _deleteButton = By.XPath("//*[contains(text(),'Delete')]");
        private readonly By _checkAllButton = By.XPath("//*[contains(@class,'checkboxHeaderCell__checkbox-header-cell')]//*[contains(@class,'checkIcon__centered--')]");
        private readonly By _launchComponent = By.XPath("//*[contains(@class,'gridRow__grid-row-wrapper')]");

        public AllLaunchesPage(IWebDriver driver) : base(driver) { }

        public Button AddFilterButton => Driver.FindElement<Button>(_addFilterButton);
        public TextField LaunchNameField => Driver.FindElement<TextField>(_launchNameField);
        public Button MoreButton => Driver.FindElement<Button>(_moreButton);
        public Checkbox TotalCheckbox => Driver.FindElement<Checkbox>(_totalCheckbox);
        public TextField SecondFilterField => Driver.FindElement<TextField>(_secondFilterField);
        public Checkbox PassedCheckbox => Driver.FindElement<Checkbox>(_passedCheckbox);
        public Button Condition => Driver.FindElement<Button>(_condition);
        public Button EqualCondition => Driver.FindElement<Button>(_equalCondition);
        public Button ActionsButton => Driver.FindElement<Button>(_actionsButton);
        public Button PageSizeButton => Driver.FindElement<Button>(_pageSizeButton);
        public Button CompareButton => Driver.FindElement<Button>(_compareButton);
        public Button DeleteButton => Driver.FindElement<Button>(_deleteButton);
        public Checkbox CheckAllButton => Driver.FindElement<Checkbox>(_checkAllButton);
        public ReadOnlyCollection<LaunchComponent> Launches => Driver.FindElements<LaunchComponent>(_launchComponent);

        public void ClickAddFilterButton() => AddFilterButton.Click();
        public void ClickMoreButton() => MoreButton.Click();
        public void ClickTotalCheckbox() => TotalCheckbox.Check();
        public void ClickPassedCheckbox() => PassedCheckbox.Check();
        public void ClickCompareButton() => CompareButton.Click();
        public void ClickDeleteButton() => DeleteButton.Click();
        public void CheckAllLaunches() => CheckAllButton.Check();
        public void ClickOnActionButton() => ActionsButton.Click();
        public void EnterLaunchName(string launchName) => LaunchNameField.EnterText(launchName);
        public void EnterSecondFilterField(string value) => SecondFilterField.EnterText(value);
        public void ClickCondition() => Condition.Click();
        public void ClickEqualCondition() => EqualCondition.Click();
        public void ScrollPageSizeButtonIntoView() => PageSizeButton.ScrollToElementJavaScript();
        public bool IsPageSizeButtonScrolledIntoView() => PageSizeButton.IsElementScrolledIntoViewJavaScript();

        public List<BasicElement> TotalValues()
        {
            List<BasicElement> totalValues = new List<BasicElement>();

            foreach (var launch in Launches)
            {
                totalValues.Add(launch.TotalValue);
            }
            return totalValues;
        }

        public List<BasicElement> PassedValues()
        {
            List<BasicElement> passedValues = new List<BasicElement>();

            foreach (var launch in Launches)
            {
                passedValues.Add(launch.PassedValue);
            }
            return passedValues;
        }

        public List<BasicElement> FailedValues()
        {
            List<BasicElement> failedValues = new List<BasicElement>();

            foreach (var launch in Launches)
            {
                failedValues.Add(launch.PassedValue);
            }
            return failedValues;
        }

        public List<BasicElement> LaunchNames()
        {
            List<BasicElement> launchNames = new List<BasicElement>();

            foreach (var launch in Launches)
            {
                launchNames.Add(launch.LaunchName);
            }
            return launchNames;
        }
    }
}
