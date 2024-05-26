using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.Elements
{
    public class Button(IWebElement element) : BasicElement(element)
    {
        public void Click()
        {
            element.Click();
        }
        
        public void ClickJS()
        {
            JSExecutor().ExecuteScript("arguments[0].click();", element);
        }

        public void ResizeElement(int xOffset, int yOffset)
        {
            Actions actions = new Actions(Driver());
            actions.ClickAndHold(element)
                .MoveByOffset(xOffset, yOffset)
                //.Release()
                .Build()
                .Perform();
        }
    }
}
