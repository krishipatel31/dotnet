﻿using EmployeeManagement.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="first name should be provided")]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [EmailDomainValidator(AllowedDomain ="gmail.com",
        ErrorMessage="only gmail.com is allowed")]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId{ get; set; }
        public string PhotoPath { get; set; }
        public Department? Department { get; set; }   

    }
}
