using System.Text.Json.Serialization;
using API.Business.Models.Responses.Items;

namespace API.Business.Models.Responses
{
    public class GetLaunchesResponse
    {
        [JsonPropertyName("content")]
        public List<LaunchItem> Content { get; set; }

        [JsonPropertyName("page")]
        public ResponseInfoItem Page { get; set; }
    }
}