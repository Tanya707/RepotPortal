using NUnit.Framework;

namespace Core.Helpers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestCaseIdAttribute : PropertyAttribute
    {
        public TestCaseIdAttribute(string id) : base("TestCaseId", id) { }
    }
}
