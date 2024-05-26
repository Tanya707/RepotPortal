using OpenQA.Selenium;

namespace Core.Elements
{
    public class TextField(IWebElement element) : BasicElement(element)
    {
        public void EnterText(string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}
