using System;

namespace HumanResources.DataModels
{
    public class HumanResource
    {
        public int EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
    }
}
