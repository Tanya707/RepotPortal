namespace API.Business.Models
{
    public static class Endpoints
    {
        public const string Launches= "/api/v1/{0}/launch";
        public const string PutLaunchesStop = "/api/v1/{0}/launch/{1}/stop";
        public const string PatchLaunchesUpdate = "/api/v1/{0}/launch/{1}/update";
        public const string DeleteLaunchById = "/api/v1/{0}/launch/{1}";
    }
}
