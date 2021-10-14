using HumanResources.Database.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace HumanResources.Database
{
    public class DatabaseConnections : IDatabaseConnections
    {
        public DatabaseConnections()
        {
            LoadDatabaseConnections();
        }

        private void LoadDatabaseConnections()
        {
            string directoryName = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            IConfiguration config = new ConfigurationBuilder()
                            .SetBasePath(directoryName)
                            .AddJsonFile(@"connectionStrings.json", true, true)
                            .Build();

            AccreditHr = config.GetSection("DatabaseConnections:AccreditHr").Value;
        }

        public string AccreditHr { get; set; }
    }
}
