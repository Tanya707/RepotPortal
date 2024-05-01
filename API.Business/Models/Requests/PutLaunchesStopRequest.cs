using API.Business.Models.Requests.Items;

namespace API.Business.Models.Requests
{
    public class PutLaunchesStopRequest
    {
        public List<AttributeItems> Attributes { get; set; }
        public string Description { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
    }
}
