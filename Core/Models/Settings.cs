
namespace Core.Models
{
    public class Settings
    {
        public ReportPortalUrl ReportPortalUrl { get; set; }
        public UserCredentials SuperadminUser { get; set; }
        public UserCredentials DefaultUser { get; set; }
        public string NameOfProject { get; set; }
        public Jira Jira { get; set; }
        public string SlackUrl { get; set; }
    }
}
