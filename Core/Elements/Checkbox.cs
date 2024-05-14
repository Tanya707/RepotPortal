using OpenQA.Selenium;

namespace Core.Elements
{
    public class Checkbox(IWebElement element) :ICheckbox
    {
        public IWebElement Element => element;
        public void Check()
        {
            if (!element.Selected)
            {
                element.Click();
            }
        }

        public void Uncheck()
        {
            if (element.Selected)
            {
                element.Click();
            }
        }

        public bool Displayed()
        {
            return element.Displayed;
        }

        public bool Enabled()
        {
            return element.Enabled;
        }
    }
}
