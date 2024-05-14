using OpenQA.Selenium;

namespace Core.Elements
{
    public class Table(IWebElement element) : ITable
    {
        public IWebElement Element => element;
        public void Click()
        {
            element.Click();
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
