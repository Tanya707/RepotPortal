using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Core.Helpers
{
    public static class JiraService
    {
        private const string IssueUrlTemplate = "{0}/rest/api/latest/issue/{1}";
        private const string IssueFieldsUpdateTemplate = IssueUrlTemplate + "/transitions?expand=transitions.fields";
        private const string IssueCommentsUpdateTemplate = IssueUrlTemplate + "/comment";
        private static Settings settings = SettingHelper.LoadFromAppSettings();

        private static string _userName = settings.Jira.JiraUser;
        private static string _password = settings.Jira.JiraPassword;
        private static string _jiraUrl = settings.Jira.JiraUrl;

        private static byte[] _authToken = Encoding.GetEncoding("ISO-8859-1").GetBytes(_userName + ":" + _password);

        private static string TestCaseId => (Type.GetType(TestContext.CurrentContext.Test.ClassName ?? string.Empty)?
            .GetMethod(TestContext.CurrentContext.Test.MethodName ?? string.Empty)?.GetCustomAttributes(false)?
            .Single(attribute => attribute is TestCaseIdAttribute) as TestCaseIdAttribute)?.Id;

        public static async void UpdateTestCaseStatus(string status)
        {
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(_authToken));
            var body = new
            {
                transition = new
                {
                    id = GetTestCaseStatusIdFromJira(status).Result
                }
            };

            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(string.Format(IssueFieldsUpdateTemplate, _jiraUrl, TestCaseId), data);
            response.EnsureSuccessStatusCode();
        }

        public static async void AddCommentToTestCase(string comment)
        {
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(_authToken));
            var body = new
            {
                body = comment
            };

            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response =
                await client.PostAsync(string.Format(IssueCommentsUpdateTemplate, _jiraUrl, TestCaseId), data);
            response.EnsureSuccessStatusCode();
        }

        public static async Task<string> GetTestCaseStatusIdFromJira(string status)
        {
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(_authToken));

            var response = await client.GetAsync(string.Format(IssueFieldsUpdateTemplate, _jiraUrl, TestCaseId));
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
            var statusId = JsonConvert.DeserializeObject<TestCaseModal>(resp).Transitions
                .FirstOrDefault(transition => transition.Name.Equals(status))?.Id;
            return statusId;
        }

    }
}
