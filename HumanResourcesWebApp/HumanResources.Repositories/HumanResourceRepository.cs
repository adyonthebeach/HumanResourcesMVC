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
            List<HumanResource> allResources = new List<HumanResource>();

            SqlCommand command = new SqlCommand("GetAllResources", _sqlConnection);
            command.CommandType = System.Data.CommandType.StoredProcedure;


            _sqlConnection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    HumanResource resource = new HumanResource();
                    resource.EmployeeNumber = int.Parse(reader["EmployeeNumber"].ToString());
                    resource.FirstName = reader["FirstName"].ToString();
                    resource.LastName = reader["LastName"].ToString();
                    resource.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                    resource.Email = reader["Email"].ToString();
                    resource.Department = reader["Department"].ToString();
                    resource.Status = reader["StatusDescription"].ToString();

                    allResources.Add(resource);
                }

                reader.Close();
            }
            _sqlConnection.Close();

            return allResources;
        }

        public HumanResource Create(HumanResource humanResource)
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
            _sqlConnection.Close();

            return humanResource;
        }

        public HumanResource Update(HumanResource humanResource)
        {
            SqlCommand command = new SqlCommand("UpdateResource", _sqlConnection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@employeenumber", humanResource.EmployeeNumber);
            command.Parameters.AddWithValue("@firstname", humanResource.FirstName);
            command.Parameters.AddWithValue("@lastname", humanResource.LastName);
            command.Parameters.AddWithValue("@dateOfBirth", humanResource.DateOfBirth);
            command.Parameters.AddWithValue("@email", humanResource.Email);
            command.Parameters.AddWithValue("@department", humanResource.Department);
            command.Parameters.AddWithValue("@status", humanResource.Status);


            _sqlConnection.Open();
            command.ExecuteNonQuery();

            _sqlConnection.Close();

            return humanResource;
        }

        public int Delete(int employeeNumber)
        {
            SqlCommand command = new SqlCommand("DeleteResource", _sqlConnection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@employeenumber", employeeNumber);


            _sqlConnection.Open();
            var updatedRecords = command.ExecuteNonQuery();

            _sqlConnection.Close();

            return updatedRecords;
        }
    }
}
