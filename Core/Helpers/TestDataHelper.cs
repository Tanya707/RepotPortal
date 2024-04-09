using Core.Models;
using Microsoft.Extensions.Configuration;

namespace Core.Helpers
{
    public class TestDataHelper
    {
        public static TotalTestData TotalTestData()
        {
            string baseDirectory = AppContext.BaseDirectory;
            string relativePath = Path.Combine("..", "..", "..", "..", "Core", "Utilities");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(baseDirectory, relativePath))
                .AddJsonFile("TotalTestData.json")
                .Build();

            return configuration.Get<TotalTestData>();
        }

        public static PassedTestData PassedTestData()
        {
            string baseDirectory = AppContext.BaseDirectory;
            string relativePath = Path.Combine("..", "..", "..", "..", "Core", "Utilities");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(baseDirectory, relativePath))
                .AddJsonFile("PassedTestData.json")
                .Build();

            return configuration.Get<PassedTestData>();
        }

        public static LaunchNameTestData LaunchNameTestData()
        {
            string baseDirectory = AppContext.BaseDirectory;
            string relativePath = Path.Combine("..", "..", "..", "..", "Core", "Utilities");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(baseDirectory, relativePath))
                .AddJsonFile("LaunchNameTestData.json")
                .Build();

            return configuration.Get<LaunchNameTestData>();
        }
    }
}
