using Core.Elements;
using Core.Logger;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UI.Business.CustomElements
{
    public class BasicElement(IWebElement element) : IBasicElement
    {
        protected ILogger _logger = new ConsoleLogger();
        public IWebElement Element => element;
        public bool Displayed()
        {
            _logger.LogDebug("Element is displayed");
            return element.Displayed;
        }

        public string GetText()
        {
            return element.Text;
        }
        public bool Enabled()
        {
            return element.Enabled;
        }

        public int Height()
        {
            return element.Size.Height;
        }

        public int Width()
        {
            return element.Size.Width;
        }

        public void ScrollToElementJavaScript()
        {
            _logger.LogDebug("Scroll element into view");
            JSExecutor().ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public bool IsElementScrolledIntoViewJavaScript()
        {
            bool isScrolledIntoView = (bool)JSExecutor().ExecuteScript("var elem = arguments[0],                 " +
                                                                     "  box = elem.getBoundingClientRect(),    " +
                                                                     "  cx = box.left + box.width / 2,         " +
                                                                     "  cy = box.top + box.height / 2,         " +
                                                                     "  e = document.elementFromPoint(cx, cy); " +
                                                                     "for (; e; e = e.parentElement) {         " +
                                                                     "  if (e === elem)                        " +
                                                                     "    return true;                         " +
                                                                     "}                                        " +
                                                                     "return false;                            ", element);
            return isScrolledIntoView;
        }

        public void DragAndDrop(IWebElement targetElement)
        {
            _logger.LogDebug("Drag And Drop element");
            Actions actions = new Actions(Driver());

            actions.ClickAndHold(element)
                .MoveToElement(targetElement)
                .Release()
                .Build()
                .Perform();
        }

        public bool Disabled()
        {
            return !element.Enabled;
        }

        public void Click()
        {
            _logger.LogDebug("Click on element");
            element.Click();
        }

        protected IJavaScriptExecutor JSExecutor()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)((IWrapsDriver)element).WrappedDriver;
            return js;
        }

        protected IWebDriver Driver()
        {
            IWebDriver driver = ((IWrapsDriver)element).WrappedDriver;
            return driver;
        }

    }
}
