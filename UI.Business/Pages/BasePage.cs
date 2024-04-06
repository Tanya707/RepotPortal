using Framework.Core.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Business.Pages
{
    public abstract class BasePage
    {
        protected static IWebDriver Driver = WebDriverFactory.GetDriver();
    }
}
