using System.Data.SqlClient;
using HumanResources.Database.Interfaces;

namespace HumanResources.Database
{
    public class AccreditHrDatabaseConnectionFactory : IConnectionFactory
    {
        private readonly IDatabaseConnections _databaseConnections;

        public AccreditHrDatabaseConnectionFactory(IDatabaseConnections databaseConnections)
        {
            _databaseConnections = databaseConnections;
        }
        public SqlConnection Create()
        {
            return new SqlConnection(_databaseConnections.AccreditHr);
        }
    }
}
