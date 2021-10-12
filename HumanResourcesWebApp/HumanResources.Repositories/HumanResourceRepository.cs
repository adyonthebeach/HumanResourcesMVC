using HumanResources.DataModels;
using HumanResources.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HumanResources.Repositories
{
    public class HumanResourceRepository : IHumanResourceRepository
    {
        private readonly SqlConnection sqlConnection;

        public HumanResourceRepository(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public List<HumanResource> GetAllHumanResources()
        {
            throw new NotImplementedException("To be done");
        }

        public void Create(HumanResource humanResource)
        {
            throw new NotImplementedException("To be Done");
        }
    }
}
