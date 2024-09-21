using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.model
{
    public class Department
    {
    public int DepartmentId { get; set; }
        [Required]
    public string DepartmentName { get; set; }

    }
}
