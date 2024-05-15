using OpenQA.Selenium;

namespace Core.Elements
{
    public interface IBasicElement
    {
        bool Displayed();
        bool Enabled();
    }
}
