using HumanResources.Database.Interfaces;
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

        public HumanResourceRepository(IConnectionFactory connectionFactory)
        {
            _sqlConnection = connectionFactory.Create();
        }

        public List<HumanResource> GetAllHumanResources()
        {
            List<HumanResource> allResources = new List<HumanResource>();

            SqlCommand command = new SqlCommand("GetAllResources", _sqlConnection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

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

        public HumanResource GetHumanResource(int employeeNumber)
        {
            HumanResource resource = new HumanResource();

            SqlCommand command = new SqlCommand("GetResource", _sqlConnection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                Parameters =
                {
                    new SqlParameter("@employeeNumber", employeeNumber)
                }
            };

            _sqlConnection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    resource.EmployeeNumber = int.Parse(reader["EmployeeNumber"].ToString());
                    resource.FirstName = reader["FirstName"].ToString();
                    resource.LastName = reader["LastName"].ToString();
                    resource.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                    resource.Email = reader["Email"].ToString();
                    resource.Department = reader["Department"].ToString();
                    resource.Status = reader["StatusDescription"].ToString();
                }

                reader.Close();
            }
            _sqlConnection.Close();

            return resource;
        }

        public HumanResource Create(HumanResource humanResource)
        {
            SqlCommand command = new SqlCommand("CreateResource", _sqlConnection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                Parameters =
                {
                    new SqlParameter("@firstName", humanResource.FirstName),
                    new SqlParameter("@lastName", humanResource.LastName),
                    new SqlParameter("@dateOfBirth", humanResource.DateOfBirth),
                    new SqlParameter("@email", humanResource.Email),
                    new SqlParameter("@department", humanResource.Department),
                    new SqlParameter("@status", humanResource.Status)
                }
            };

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
            SqlCommand command = new SqlCommand("UpdateResource", _sqlConnection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                Parameters =
                {
                    new SqlParameter("@employeeNumber", humanResource.EmployeeNumber),
                    new SqlParameter("@firstName", humanResource.FirstName),
                    new SqlParameter("@lastName", humanResource.LastName),
                    new SqlParameter("@dateOfBirth", humanResource.DateOfBirth),
                    new SqlParameter("@email", humanResource.Email),
                    new SqlParameter("@department", humanResource.Department),
                    new SqlParameter("@status", humanResource.Status)
                }
            };

            _sqlConnection.Open();
            command.ExecuteNonQuery();

            _sqlConnection.Close();

            return humanResource;
        }

        public int Delete(int employeeNumber)
        {
            SqlCommand command = new SqlCommand("DeleteResource", _sqlConnection)
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                Parameters =
                {
                    new SqlParameter("@employeeNumber", employeeNumber)
                }
            };

            _sqlConnection.Open();
            var updatedRecords = command.ExecuteNonQuery();

            _sqlConnection.Close();

            return updatedRecords;
        }
    }
}
