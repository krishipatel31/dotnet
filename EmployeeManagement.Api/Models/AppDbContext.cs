using EmployeeManagement.model;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagement.Api.Models
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {
            }

            public DbSet<Employee> Employees { get; set; }
            public DbSet<Department> Departments { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                //Seed Departments Table
                modelBuilder.Entity<Department>().HasData(
                    new Department { DepartmentId = 1, DepartmentName = "IT" });
                modelBuilder.Entity<Department>().HasData(
                    new Department { DepartmentId = 2, DepartmentName = "HR" });
                modelBuilder.Entity<Department>().HasData(
                    new Department { DepartmentId = 3, DepartmentName = "Payroll" });
                modelBuilder.Entity<Department>().HasData(
                    new Department { DepartmentId = 4, DepartmentName = "Admin" });

                modelBuilder.Entity<Employee>().HasData(new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Mr",
                    LastName = "Python",
                    Email = "khip31@gmail.com",
                    DateOfBirth = new DateTime(2002, 8, 31),
                    Gender = Gender.Female,
                    DepartmentId = 1,
                    PhotoPath = "images/5.png"
                });
                modelBuilder.Entity<Employee>().HasData(new Employee
                {
                    EmployeeId = 2,
                    FirstName = " Ms",
                    LastName = "Java",
                    Email = "ip31@gmail.com",
                    DateOfBirth = new DateTime(2002, 8, 31),
                    Gender = Gender.Female,
                    DepartmentId = 2,
                    PhotoPath = "images/2.png"
                });
                modelBuilder.Entity<Employee>().HasData(new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Mr",
                    LastName = "Php",
                    Email = "kriship31@gmail.com",
                    DateOfBirth = new DateTime(2002, 8, 31),
                    Gender = Gender.Female,
                    DepartmentId = 3,
                    PhotoPath = "images/3.png"
                });
                modelBuilder.Entity<Employee>().HasData(new Employee
                {
                    EmployeeId = 4,
                    FirstName = " Mr",
                    LastName = "Dot Net",
                    Email = "kriship31@gmail.com",
                    DateOfBirth = new DateTime(2002, 8, 31),
                    Gender = Gender.Female,
                    DepartmentId = 4,
                    PhotoPath = "images/4.png"
                });

            }
            }
        }

  

