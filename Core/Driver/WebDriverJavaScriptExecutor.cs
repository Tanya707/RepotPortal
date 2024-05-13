using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Driver
{
    public class WebDriverJavaScriptExecutor
    {
        private readonly IWebDriver _driver;

        public WebDriverJavaScriptExecutor(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public bool IsElementScrolledIntoView(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
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

        public void ClickElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].click();", element);
        }
    }
}
