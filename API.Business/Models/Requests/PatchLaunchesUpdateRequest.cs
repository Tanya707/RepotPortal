using API.Business.Models.Requests.Items;

namespace API.Business.Models.Requests
{
    public class PatchLaunchesUpdateRequest
    {
        public List<AttributeItems> Attributes { get; set; }
        public string Description { get; set; }
        public string Mode { get; set; }
    }
}
