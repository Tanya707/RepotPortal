using Framework.Core.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Contexts
{
    public class LoginContext
    {
        protected IWebDriver driver;
        private readonly By logInWithEpam = By.XPath("//button[contains(@class, 'bigButton__big-button')]");

        public IWebElement LogInWithEpam => driver.FindElement(logInWithEpam);

        public void ClickLoginWithEpam()
        {
            
        }


    }
}
