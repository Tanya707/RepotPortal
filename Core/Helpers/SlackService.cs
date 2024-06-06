using System.Text;
using Core.Models;
using Newtonsoft.Json;

namespace Core.Helpers
{
    public class SlackService
    {
        private static readonly System.Net.Http.HttpClient Client = new System.Net.Http.HttpClient();
        private static Settings settings = SettingHelper.LoadFromAppSettings();
        private static readonly string SlackUrl = settings.SlackUrl;

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
