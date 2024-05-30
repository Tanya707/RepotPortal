using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Core.Helpers
{
    public class SlackService
    {
        private static readonly System.Net.Http.HttpClient Client = new System.Net.Http.HttpClient();
        private static readonly string SlackUrl = "https://hooks.slack.com/services/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";

        public async void PostNotification(string message)
        {
            var body = new
            {
                text = message
            };

            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(SlackUrl, data);
            await response.Content.ReadAsStringAsync();
        }
    }
}
