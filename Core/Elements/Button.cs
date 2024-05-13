using OpenQA.Selenium;

namespace Core.Elements
{
    public class Button(IWebElement element) : IButton
    {
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
    }
}
