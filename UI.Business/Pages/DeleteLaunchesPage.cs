using Core.Driver;
using OpenQA.Selenium;
using UI.Business.CustomElements;

namespace UI.Business.Pages
{
    public class DeleteLaunchesPage : BasePage
    {
        private readonly By _deleteButton = By.XPath("//*[contains(@class,'bigButton__color-tomato')]");

        public DeleteLaunchesPage(IWebDriver driver) : base(driver) { }

        public Button DeleteButton => Driver.FindElement<Button>(_deleteButton);

        public void ClickDeleteButton() => DeleteButton.Click();
    }
}
