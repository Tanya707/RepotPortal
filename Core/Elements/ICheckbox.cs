namespace Core.Elements
{
    internal interface ICheckbox:IBasicElement
    {
        void Check();

        void Uncheck();
        bool Enabled();
    }
}
