using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.Elements
{
    public class BasicElement(IWebElement element) : IBasicElement
    {
        public IWebElement Element => element;
        public bool Displayed()
        {
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
            IJavaScriptExecutor js = (IJavaScriptExecutor)((IWrapsDriver)element).WrappedDriver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public bool IsElementScrolledIntoView()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)((IWrapsDriver)element).WrappedDriver;
            bool isScrolledIntoView = (bool)js.ExecuteScript("var elem = arguments[0],                 " +
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
            Actions actions = new Actions(((IWrapsDriver)element).WrappedDriver);
            actions.DragAndDrop(element, targetElement).Build().Perform();
        }

    }
}
