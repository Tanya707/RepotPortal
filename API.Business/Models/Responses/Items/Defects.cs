namespace API.Business.Models.Responses.Items
{
    public class Defects
    {
        public ProductBug ProductBug { get; set; }
        public ToInvestigate ToInvestigate { get; set; }
        public AutomationBug AutomationBug { get; set; }
    }
}
