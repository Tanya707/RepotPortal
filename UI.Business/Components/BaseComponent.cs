using OpenQA.Selenium;

namespace UI.Business.Components
{
    public class BaseComponent {
        protected ISearchContext SearchContext;
        protected BaseComponent(ISearchContext searchContext)
        {
            SearchContext = searchContext;
        }

    }
}
