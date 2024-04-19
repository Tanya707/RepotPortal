using Core.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Core.Helpers
{
    public class TestDataHelper
    {
        public static TestData TestData(string path)
        {
            string baseDirectory = AppContext.BaseDirectory;
            string relativePath = Path.Combine("..", "..", "..", "..", path, "TestData");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(baseDirectory, relativePath))
                .AddJsonFile("TestData.json")
                .Build();

            return configuration.Get<TestData>();
        }

     }
}
