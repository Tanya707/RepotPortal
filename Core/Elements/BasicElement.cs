using Core.Logger;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.Elements
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
            _logger.LogDebug($"Get text {element.Text}");
            return element.Text;
        }
        public bool Enabled()
        {
            _logger.LogDebug("Element is enabled");
            return element.Enabled;
        }

        public int Height()
        {
            _logger.LogDebug($"Elements height is {element.Size.Height}");
            return element.Size.Height;
        }

        public int Width()
        {
            _logger.LogDebug($"Elements width is {element.Size.Width}");
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
            Actions actions = new Actions(Driver());
            actions.DragAndDrop(element, targetElement).Build().Perform();
        }

        public bool Disabled()
        {
            _logger.LogDebug("Element is disabled");
            return !element.Enabled;
        }

        public void Click()
        {
            _logger.LogDebug("Click on element");
            element.Click();
        }

        public IJavaScriptExecutor JSExecutor()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)((IWrapsDriver)element).WrappedDriver;
            return js;
        }

        public IWebDriver Driver()
        {
            IWebDriver driver = ((IWrapsDriver)element).WrappedDriver;
            return driver;
        }

    }
}
