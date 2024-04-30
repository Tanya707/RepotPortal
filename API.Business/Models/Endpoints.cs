namespace API.Business.Models
{
    public static class Endpoints
    {
        public const string GenerateProjectData = "/api/v1/demo/{0}/generate";
        public const string GetLaunchNames = "/api/v1/{0}/launch/names";
        public const string GetLaunchesByFilter = "/api/v1/{0}/launch";
        public const string GetLatestLaunchByFilter = "/api/v1/{0}/launch/latest";

        public const string Users = "/api/users";
        public const string SearchUsers = "/api/users/all";

    }
}
