using EmployeeManagement.Models.CustomValidators;
using EmployeeManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "First name is mandatory")]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailDomainValidator(AllowedDomain = "ncr.com")]
        public string Email { get; set; }
        [Compare("Email",
            ErrorMessage = "Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBrith { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string PhotoPath { get; set; }
    }
}
