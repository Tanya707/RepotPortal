using Core.Models;
using Microsoft.Extensions.Configuration;

namespace Core.Helpers
{
    public static class SettingHelper
    {
        private static readonly string baseDirectory = AppContext.BaseDirectory;
        private static readonly string relativePath = Path.Combine("Configuration");

        public static Settings LoadFromAppSettings()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(baseDirectory, relativePath))
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration.Get<Settings>();
        }

        public static ConfigSettings LoadFromConfigSettings()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(baseDirectory, relativePath))
                .AddJsonFile("configsettings.json")
                .Build();

            return configuration.Get<ConfigSettings>();
        }
    }
}
