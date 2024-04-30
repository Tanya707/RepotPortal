using API.Business.Models.Responses.Items;

namespace API.Business.Models.Responses
{
    public class DeleteLaunchesResponse
    {
        public List<Error> Errors { get; set; }
        public List<int> NotFound { get; set; }
        public List<int> SuccessfullyDeleted { get; set; }
    }
}