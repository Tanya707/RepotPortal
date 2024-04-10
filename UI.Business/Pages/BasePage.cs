using Framework.Core.Utilities;
using OpenQA.Selenium;

namespace UI.Business.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected BasePage(IWebDriver driver) {
            Driver = driver;
        }
    }
}
