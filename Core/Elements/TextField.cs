using Core.Logger;
using OpenQA.Selenium;

namespace Core.Elements
{
    public class TextField(IWebElement element) : BasicElement(element)
    {
        public void EnterText(string text)
        {
            _logger.LogDebug($"Enter tex {text}");
            element.Clear();
            element.SendKeys(text);
        }
    }
}
