using Core.Driver;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using Core.Elements;
using UI.Business.CustomElements;

namespace UI.Business.Pages
{
    public class CompareLaunchesPage : BasePage
    {
        private readonly By _compareLaunchesName = By.XPath("//*[contains(@class,'modalHeader__modal-title')]");
        private readonly By _compareLaunchesWindow = By.XPath("//*[contains(@class,'modalLayout__modal-window-')]");

        public CompareLaunchesPage(IWebDriver driver) : base(driver) { }

        public BasicElement CompareLaunchesName => Driver.FindElement<BasicElement>(_compareLaunchesName);
        public BasicElement CompareLaunchesWindow => Driver.FindElement<BasicElement>(_compareLaunchesWindow);
    }
}
