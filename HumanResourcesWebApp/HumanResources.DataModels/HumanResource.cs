using System;
using System.ComponentModel.DataAnnotations;

namespace HumanResources.DataModels
{
    public class HumanResource
    {
        public int EmployeeNumber { get; set; }

        [Required(ErrorMessage = "You Must Enter a First Name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You Must Enter a Last Name.")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "You must enter an email address.")]
        [EmailAddress(ErrorMessage = "You must enter a valid Email Address.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "You must enter a valid Email Address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You Must Enter a Department.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "You Must Choose a Status.")]
        public string Status { get; set; }
    }
}
