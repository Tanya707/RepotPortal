using OpenQA.Selenium;
using Core.Driver;
using UI.Business.CustomElements;

namespace UI.Business.Components
{
    public class DashboardTableComponent : BaseComponent
    {
        private readonly By _dashboardName = By.XPath(".//*[contains(@class,'widgetHeader__widget-name-block')]");
        private readonly By _dashboardWidget = By.XPath(".//*[contains(@class,'draggable-field widget')]");
        private readonly By _resizeButton = By.XPath(".//*[contains(@class,'react-resizable-handle')]");
        private readonly By _frameOfTable = By.XPath(".//*[contains(@class,'azyload-wrapper widget__lazy-load-wrapper')]");

        public DashboardTableComponent(ISearchContext searchContext) : base(searchContext) { }

        public BasicElement DashboardName => SearchContext.FindElement<BasicElement>(_dashboardName);
        public BasicElement DashboardWidget => SearchContext.FindElement<BasicElement>(_dashboardWidget);
        public Button ResizeButton => SearchContext.FindElement<Button>(_resizeButton);
        public BasicElement FrameOfTable => SearchContext.FindElement<BasicElement>(_frameOfTable);
        public string DashboardNameText() => DashboardName.GetText();
        public void ResizeTable(int xOffset, int yOffset) => ResizeButton.ResizeElement(xOffset, yOffset);
    }
}
