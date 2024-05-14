using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UI.Business.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected Actions Actions;
        protected BasePage(IWebDriver driver) {
            Driver = driver;
            Actions = new Actions(driver);
        }
    }
}
