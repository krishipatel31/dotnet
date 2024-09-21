using EmployeeManagement.model;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeServices EmployeeService { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
        public int SelectedEmployeesCount { get; set; } = 0;

        public bool ShowFooter { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }
        protected async Task EmployeeDeleted()
        {
        Employees=(await EmployeeService.GetEmployees()).ToList();  
        }
        protected void OnEmployeeSelectionChanged(bool isSelected) {
         if (isSelected)
            {
                SelectedEmployeesCount++;   
            }
            else
            {
                SelectedEmployeesCount--;   
            }
        
        }
    }
}