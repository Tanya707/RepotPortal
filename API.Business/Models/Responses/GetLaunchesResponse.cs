using API.Business.Models.Responses.Items;
using System.Net;

namespace API.Business.Models.Responses
{
    public class GetLaunchesResponse
    {
        public List<Execution> Content { get; set; }
        public Page Page { get; set; }
    }
}