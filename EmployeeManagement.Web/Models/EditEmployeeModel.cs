using EmployeeManagement.model;
using EmployeeManagement.Models.CustomValidators;
using System.ComponentModel.DataAnnotations;
using System;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel

    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "first name should be provided")]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [EmailDomainValidator(AllowedDomain = "gmail.com",
        ErrorMessage = "only gmail.com is allowed")]
        public string Email { get; set; }
        [CompareProperty("Email",ErrorMessage ="Email and Conform Email must match")]
        public string ConfirmEmail { get; set; }

        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int? DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        [ValidateComplexType]
        public Department Department { get; set; } = new Department();
    }
}
