using HumanResources.Database.Interfaces;
using Microsoft.Extensions.Configuration;
using System.IO;

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
            IConfiguration config = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile(@"connectionStrings.json", true, true)
                            .Build();

            AccreditHr = config.GetSection("DatabaseConnections:AccreditHr").Value;
        }

        public string AccreditHr { get; set; }
    }
}
