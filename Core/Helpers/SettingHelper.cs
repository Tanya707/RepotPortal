using Core.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
