using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Core.Driver
{
    public static class WebDriverExtensions
    {
        public static T FindElement<T>(this IWebDriver driver, By locator)
        {
            IWebElement element = driver.FindElement(locator);
            return (T)Activator.CreateInstance(typeof(T), element);
        }

        public static ReadOnlyCollection<T> FindElements<T>(this IWebDriver driver, By locator) 
        {
            ReadOnlyCollection<IWebElement> elements = driver.FindElements(locator);
            List<T> customElements = new List<T>();

            foreach (var element in elements)
            {
                customElements.Add((T)Activator.CreateInstance(typeof(T), element));
            }

            return customElements.AsReadOnly();
        }
    }
}
