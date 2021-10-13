using HumanResources.DataModels;
using HumanResources.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HumanResources.Repositories
{
    public class HumanResourceRepository : IHumanResourceRepository
    {
        private readonly SqlConnection _sqlConnection;

        public HumanResourceRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public List<HumanResource> GetAllHumanResources()
        {
            throw new NotImplementedException("To be done");
        }

        public HumanResource Create(HumanResource humanResource)
        {
            using (_sqlConnection)
            {
                SqlCommand command = new SqlCommand("CreateResource", _sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@firstname", humanResource.FirstName);
                command.Parameters.AddWithValue("@lastname", humanResource.LastName);
                command.Parameters.AddWithValue("@dateOfBirth", humanResource.DateOfBirth);
                command.Parameters.AddWithValue("@email", humanResource.Email);
                command.Parameters.AddWithValue("@department", humanResource.Department);
                command.Parameters.AddWithValue("@status", humanResource.Status);
                

                _sqlConnection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        humanResource.EmployeeNumber = int.Parse(reader["EmployeeNumber"].ToString());
                    }

                    reader.Close();
                }
            }

            return humanResource;
        }
    }
}
