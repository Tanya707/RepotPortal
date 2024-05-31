using Core.Logger;
using OpenQA.Selenium;

namespace UI.Business.CustomElements
{
    public class TextField(IWebElement element) : BasicElement(element)
    {
        public void EnterText(string text)
        {
            _logger.LogDebug($"Enter tex {text}");
            Element.Clear();
            Element.SendKeys(text);
        }
    }
}
