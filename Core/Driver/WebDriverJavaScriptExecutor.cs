using OpenQA.Selenium;

namespace Core.Driver
{
    public static class WebDriverJavaScriptExecutor
    {

        public static void ScrollToElementJS(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static bool IsElementScrolledIntoViewJS(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
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

        public static void ClickElementJS(this IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }
    }
}
