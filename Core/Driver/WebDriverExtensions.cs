using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Core.Driver
{
    public static class WebDriverExtensions
    {
        public static T FindElement<T>(this ISearchContext searchContext, By locator)
        {
            IWebElement element = searchContext.FindElement(locator);
            return (T)Activator.CreateInstance(typeof(T), element);
        }

        public static ReadOnlyCollection<T> FindElements<T>(this ISearchContext searchContext, By locator)
        {
            ReadOnlyCollection<IWebElement> elements = searchContext.FindElements(locator);
            List<T> customElements = new List<T>();

            foreach (var element in elements)
            {
                customElements.Add((T)Activator.CreateInstance(typeof(T), element));
            }

            return customElements.AsReadOnly();
        }
    }
}
