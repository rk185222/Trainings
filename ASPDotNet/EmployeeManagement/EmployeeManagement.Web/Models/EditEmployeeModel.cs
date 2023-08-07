using EmployeeManagement.Models.CustomValidators;
using EmployeeManagement.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "The Organization Nickname field is required.")]
        [MaxLength(30, ErrorMessage = "Organization Nickname must be 30 characters or less.")]
        [RegularExpression("([a-zA-Z0-9]* *)*",
            ErrorMessage = "Organization Nickname can only contain letters, numbers and spaces.")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
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
