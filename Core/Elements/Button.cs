using Core.Logger;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.Elements
{
    public class Button(IWebElement element) : BasicElement(element)
    {
        public void Click()
        {
            _logger.LogDebug("Click on button");
            element.Click();
        }
        
        public void ClickJS()
        {
            _logger.LogDebug("Click on button with JS");
            JSExecutor().ExecuteScript("arguments[0].click();", element);
        }

        public void ResizeElement(int xOffset, int yOffset)
        {
            _logger.LogDebug("Resizing element");
            Actions actions = new Actions(Driver());
            actions.ClickAndHold(element)
                .MoveByOffset(xOffset, yOffset)
                //.Release()
                .Build()
                .Perform();
        }
    }
}
