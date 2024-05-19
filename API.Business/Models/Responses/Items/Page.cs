namespace API.Business.Models.Responses.Items
{
    public class Page
    {
        public int Number { get; set; }
        public int Size { get; set; }
        public int TotalElements { get; set; }
        public int TotalPages { get; set; }
    }
}
