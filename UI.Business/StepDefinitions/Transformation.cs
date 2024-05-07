using Reqnroll;
using Core.Models;

namespace UI.Business.StepDefinitions
{
    [Binding]
    public class Transforms
    {
        [StepArgumentTransformation]
        public List<UserCredentials> Transform(DataTable table)
        {
            return table.CreateSet<UserCredentials>().ToList();
        }
    }
}
