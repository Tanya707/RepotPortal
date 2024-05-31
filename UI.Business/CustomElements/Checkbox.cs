using Core.Logger;
using OpenQA.Selenium;

namespace UI.Business.CustomElements
{
    public class Checkbox(IWebElement element) : BasicElement(element)
    {
        public void Check()
        {
            if (!Element.Selected)
            {
                _logger.LogDebug("Checking checkbox");
                Click();
            }
            _logger.LogDebug("Checkbox is already checked");
        }

        public void Uncheck()
        {
            if (Element.Selected)
            {
                _logger.LogDebug("Unchecking checkbox");
                Click();
            }
            _logger.LogDebug("Checkbox is already unchecked");
        }
    }
}
