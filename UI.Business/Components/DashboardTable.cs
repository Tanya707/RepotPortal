using OpenQA.Selenium;
using Core.Driver;
using Core.Elements;
using UI.Business.CustomElements;

namespace UI.Business.Components
{
    public class DashboardTable:BaseComponent
    {
        private readonly By _dashboardName = By.XPath(".//*[contains(@class,'widgetHeader__widget-name-block')]");
        private readonly By _dashboardWidget = By.XPath(".//*[contains(@class,'widgetHeader__info-block')]");
        private readonly By _resizeButton = By.XPath(".//*[contains(@class,'react-resizable-handle')]");
        private readonly By _frameOfTable = By.XPath(".//*[contains(@class,'azyload-wrapper widget__lazy-load-wrapper')]");

        public DashboardTable(ISearchContext searchContext) : base(searchContext) { }

        public BasicElement DashboardName => SearchContext.FindElement<BasicElement>(_dashboardName);
        public BasicElement DashboardWidget => SearchContext.FindElement<BasicElement>(_dashboardWidget);
        public Button ResizeButton => SearchContext.FindElement<Button>(_resizeButton);
        public BasicElement FrameOfTable => SearchContext.FindElement<BasicElement>(_frameOfTable);
        public string DashboardNameText() => DashboardName.GetText();
        public void ResizeTable(int xOffset, int yOffset) => ResizeButton.ResizeElement(xOffset, yOffset);

    }
}
