using System.Net;
using System.Text.Json.Serialization;

namespace API.Business.Models.Responses
{
    public class BadRequestResponse
    {
        [JsonPropertyName("errorCode")]
        public int ErrorCode { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}