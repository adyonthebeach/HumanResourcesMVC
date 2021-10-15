using HumanResources.Database.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace HumanResources.Database
{
    public class DatabaseConnections : IDatabaseConnections
    {
        public string AccreditHr { get; set; }

        public DatabaseConnections()
        {
            LoadDatabaseConnections();
        }

        private void LoadDatabaseConnections()
        {
            var directoryName = GetConfigurationFileDirectoryName();
            var configurations = GetConfigurations(directoryName);

            AccreditHr = GetAccreditHrConnection(configurations);
        }

        private static string GetAccreditHrConnection(IConfiguration configurations)
        {
            return configurations.GetSection("DatabaseConnections:AccreditHr").Value;
        }

        private static IConfiguration GetConfigurations(string directoryName)
        {
            return new ConfigurationBuilder()
                            .SetBasePath(directoryName)
                            .AddJsonFile(@"connectionStrings.json", true, true)
                            .Build();
        }

        private static string GetConfigurationFileDirectoryName()
        {
            return new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
        }
    }
}
