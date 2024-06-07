using Core.HttpClient;
using Core.Models;
using NUnit.Framework.Interfaces;

namespace Core.Helpers
{
    public class JiraClient
    {
        private static Settings settings = SettingHelper.LoadFromAppSettings();
        private static string _userName = settings.Jira.JiraUser;
        private static string _password = settings.Jira.JiraPassword;
        private static string _jiraUrl = settings.Jira.JiraUrl;
        private static string _issueEndpoint= settings.Jira.IssueEndpoint;
        private static string _isAutomatedField = settings.Jira.IsAutomatedField;

        public static void UpdateTestCaseStatus(string id, TestStatus status)
        {
            var body = new
            {
                fields = new Dictionary<string, string>
                {
                    { _isAutomatedField, Convert.ToString(status == TestStatus.Passed? status : "Failed") }
                }
            };

            IHttpClient _apiClient = new ClientOfHttp(_jiraUrl);
            
            _apiClient.Put(String.Format(_issueEndpoint, id), body, new List<KeyValuePair<string, string>>
            {
                new("Authorization", "Basic " + Convert
                    .ToBase64String(System.Text.Encoding.ASCII.GetBytes($"{_userName}:{_password}")))
            });
          
        }
    }
}
