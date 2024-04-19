using Core.Models;
using Microsoft.Extensions.Configuration;

namespace Core.Helpers
{
    public class SettingHelper
    {
        public static Settings LoadFromAppSettings()
        {
            string baseDirectory = AppContext.BaseDirectory;
            string relativePath = Path.Combine("..", "..", "..", "..", "Core", "Configuration");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(baseDirectory, relativePath))
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration.Get<Settings>();
        }

        public static ConfigSettings LoadFromConfigSettings()
        {
            string baseDirectory = AppContext.BaseDirectory;
            string relativePath = Path.Combine("..", "..", "..", "..", "Core", "Configuration");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(baseDirectory, relativePath))
                .AddJsonFile("configsettings.json")
                .Build();

            return configuration.Get<ConfigSettings>();
        }
    }
}
