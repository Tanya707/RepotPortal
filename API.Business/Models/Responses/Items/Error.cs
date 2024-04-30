namespace API.Business.Models.Responses.Items
{
    public class Error
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
