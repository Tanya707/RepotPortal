using System.Text.Json.Serialization;
using API.Business.Models.Responses.Items;

namespace API.Business.Models.Responses
{
    public class SearchUsersResponse
    {
        [JsonPropertyName("content")]
        public List<UserItem> UserList { get; set; }

        [JsonPropertyName("page")]
        public ResponseInfoItem ResponseInfo { get; set; }
    }
}