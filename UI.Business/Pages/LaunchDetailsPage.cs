using Core.Driver;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using Core.Elements;
using UI.Business.CustomElements;

namespace UI.Business.Pages
{
  

    public class LaunchDetailsPage : BasePage
    {
        private readonly By _suiteGroup = By.XPath("//*[contains(@class,'entitiesGroup__entities-group')]");

        public LaunchDetailsPage(IWebDriver driver) : base(driver) { }

        public BasicElement SuiteGroup => Driver.FindElement<BasicElement>(_suiteGroup);
    }
}
