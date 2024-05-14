using OpenQA.Selenium;

namespace Core.Elements
{
    public class TextField(IWebElement element) : ITextField
    {
        public void EnterText(string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public bool Displayed()
        {
            return element.Displayed;
        }
        public bool Enabled()
        {
            return element.Enabled;
        }

        public bool Disabled()
        {
            return !element.Enabled;
        }
    }
}
