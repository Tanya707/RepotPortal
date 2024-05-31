using Core.Logger;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UI.Business.CustomElements
{
    public class Button(IWebElement element) : BasicElement(element)
    {
        public void ClickJS()
        {
            _logger.LogDebug("Click on button with JS");
            JSExecutor().ExecuteScript("arguments[0].click();", Element);
        }

        public void ResizeElement(int xOffset, int yOffset)
        {
            _logger.LogDebug("Resizing element");
            Actions actions = new Actions(Driver());
            actions.ClickAndHold(Element)
                .MoveByOffset(xOffset, yOffset)
                .Release()
                .Build()
                .Perform();
        }
    }
}
