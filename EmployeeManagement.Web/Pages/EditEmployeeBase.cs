using AutoMapper;
using EmployeeManagement.model;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase :ComponentBase
    {
    

        [Inject]
        public IEmployeeServices _EmployeeServices { get; set; }
        public string PageHeaderText {  get; set; } 
        private Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();
        [Inject]
        public IDepartmentService _DepartmentService { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();  
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected PragimTech.Components.ConfirmBase DeleteConfirmation { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);

            if(employeeId != 0) 
            {
                PageHeaderText = "Edit Employee";
                Employee = await _EmployeeServices.GetEmployee(int.Parse(Id));
            }
            else
            {
                PageHeaderText = "Create Employee";
                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/man.png"
                };
            }

            Departments=(await _DepartmentService.GetDepartments()).ToList();

            Mapper.Map(Employee, EditEmployeeModel);

          //  EditEmployeeModel.EmployeeId = Employee.EmployeeId;
          //  EditEmployeeModel.FirstName = Employee.FirstName;
          //  EditEmployeeModel.LastName = Employee.LastName;
          //  EditEmployeeModel.Email = Employee.Email;
          //  EditEmployeeModel.ConfirmEmail = Employee.Email;
          //  EditEmployeeModel.DateOfBirth = Employee.DateOfBirth;
          //  EditEmployeeModel.Gender = Employee.Gender;
           // EditEmployeeModel.PhotoPath = Employee.PhotoPath;
          //  EditEmployeeModel.DepartmentId = Employee.DepartmentId;
           // EditEmployeeModel.Department = Employee.Department;

        }
        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditEmployeeModel, Employee);

            Employee result = null;

            if (Employee.EmployeeId != 0)
            {

             result = await _EmployeeServices.UpdateEmployee(Employee);
            }
            else
            {
                result=await _EmployeeServices.CreateEmployee(Employee);   
            }

            if(result !=null)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }
        protected async Task ConfirmDelete_Click()
        {
         await _EmployeeServices.DeleteEmployee(Employee.EmployeeId);
         NavigationManager.NavigateTo("/");
        }
    }
}
