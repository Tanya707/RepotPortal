using OpenQA.Selenium;

namespace UI.Business.Components
{
    public class BaseComponent {
        protected IWebDriver Driver;
        protected BaseComponent(IWebDriver driver)
        {
            Driver = driver;
        }

    }
}
