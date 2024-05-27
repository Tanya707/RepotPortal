using OpenQA.Selenium;
using Core.Driver;
using Core.Elements;
using UI.Business.CustomElements;

namespace UI.Business.Components
{
    public class LaunchComponent : BaseComponent
    {
        private readonly By _totalValue = By.XPath(".//*[contains(@statuses,'PASSED,FAILED,SKIPPED,INTERRUPTED')]");
        private readonly By _passedValue = By.XPath(".//*[@statuses='PASSED']");
        private readonly By _failedValue = By.XPath(".//*[contains(@statuses,'FAILED,INTERRUPTED')]");
        private readonly By _launchName = By.XPath(".//*[contains(@class, 'itemInfo__name-link')]/*[contains(@class,'tooltip__tooltip-trigger')]");
        private readonly By _selectCheckBox = By.XPath(".//*[contains(@class,'checkIcon__square')]");

        public LaunchComponent(ISearchContext searchContext) : base(searchContext) { }

        public BasicElement TotalValue => SearchContext.FindElement<BasicElement>(_totalValue);
        public BasicElement PassedValue => SearchContext.FindElement<BasicElement>(_passedValue);
        public BasicElement FailedValue => SearchContext.FindElement<BasicElement>(_failedValue);
        public BasicElement LaunchName => SearchContext.FindElement<BasicElement>(_launchName);
        public Checkbox SelectCheckBox => SearchContext.FindElement<Checkbox>(_selectCheckBox);

    }
}
