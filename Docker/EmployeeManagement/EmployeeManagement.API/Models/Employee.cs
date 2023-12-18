using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.API.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name ="Office Email")]
        public string Email { get; set; } = string.Empty;

        public Dept Department { get; set; } 
    }
}
