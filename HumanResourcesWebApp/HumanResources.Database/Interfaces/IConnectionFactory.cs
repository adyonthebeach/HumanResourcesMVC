using System.Data.SqlClient;

namespace HumanResources.Database.Interfaces
{
    public interface IConnectionFactory
    {
        SqlConnection Create();
    }
}
