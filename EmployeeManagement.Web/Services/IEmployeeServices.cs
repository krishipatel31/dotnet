﻿using EmployeeManagement.model;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public interface IEmployeeServices
    {
        Task <IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(Employee updatedEmployee);
        Task<Employee> CreateEmployee(Employee newEmployee);
        Task DeleteEmployee(int id);
    }
}
