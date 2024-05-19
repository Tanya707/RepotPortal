namespace API.Business.Models.Requests
{
    public class ApiRequest
    {
        public string NameOfProject { get; set; }
        public int LaunchNumber { get; set; }
        public object BodyOfRequest { get; set; }
    }
}
