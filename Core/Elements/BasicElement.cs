using OpenQA.Selenium;

namespace Core.Elements
{
    public class BasicElement(IWebElement element) : IBasicElement
    {
        public IWebElement Element => element;
        public bool Displayed()
        {
            return element.Displayed;
        }

        public string GetText()
        {
            return element.Text;
        }

    }
}
