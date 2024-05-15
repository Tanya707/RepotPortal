using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace Core.Elements
{
    public class Button(IWebElement element) : IBasicElement
    {
        public IWebElement Element => element;
        public void Click()
        {
            element.Click();
        }

        public bool Enabled()
        {
            return element.Enabled;
        }

        public bool Disabled()
        {
            return !element.Enabled;
        }

        public bool Displayed()
        {
            return element.Displayed;
        }

        public void ClickJS()
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)((IWrapsDriver)element).WrappedDriver;
            jsExecutor.ExecuteScript("arguments[0].click();", element);
        }

        public void ScrollToElementJS()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)((IWrapsDriver)element).WrappedDriver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public bool IsElementScrolledIntoViewJS()
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

        public void DragAndDropAction(IWebElement targetElement)
        {
            Actions actions = new Actions(((IWrapsDriver)element).WrappedDriver);
            actions.DragAndDrop(element, targetElement).Build().Perform();
        }

        public void ResizeElement(int xOffset, int yOffset)
        {
            Actions actions = new Actions(((IWrapsDriver)element).WrappedDriver);
            actions.ClickAndHold(element)
                .MoveByOffset(xOffset, yOffset)
                //.Release()
                .Build()
                .Perform();
        }
    }
}
