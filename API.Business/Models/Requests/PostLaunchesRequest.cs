namespace API.Business.Models.Requests
{
    public class PostLaunchesRequest
    {
        public List<Attribute> Attributes { get; set; }
        public string Description { get; set; }
        public string Mode { get; set; }
        public string Name { get; set; }
        public bool Rerun { get; set; }
        public string RerunOf { get; set; }
        public DateTime StartTime { get; set; }
    }
}
