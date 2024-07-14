using Microsoft.EntityFrameworkCore;
using Store_Management.Data;
using Store_Management.Data.Models;
using Store_Management.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management.Services
{
    public class EmployeeService
    {
        private StoreDbContext Context { get; set; }
        public EmployeeService() { }

        private void StartTransaction()
        {
            Context = new StoreDbContext();
        }
        public string HashPassword()
        {
            return string.Empty;
        }

        public async Task<Employee?> FindByEmail(string email)
        {
            StartTransaction();
            return await Context.Employees.FirstOrDefaultAsync(emp => emp.Email.Equals(email));

        }
        public async Task<Employee> Signup(string fullName, string email, string password,string confirmPassword, Employee.Role role)
        {
            if (!password.Equals(confirmPassword)) throw new Exception("Password not match");

            StartTransaction();
            Employee? check = await FindByEmail(email);
            if (check != null)
            {
                throw new ArgumentException("Employee already exist!");
            }

            PasswordHasheHelper passwordHasheHelper = new PasswordHasheHelper();
            string hashPassword = passwordHasheHelper.HashPassword(password);

            Employee employee = new Employee
            {
                FullName = fullName,
                Email = email,
                Password = hashPassword,
                RoleId = (int)role,
                CreatedBy = 1,
                CreatedDate = DateTime.Now


            };
            var addedEmp = await AddOne(employee);
            return addedEmp;

        }

        public async Task<Employee> Login(string email, string password)
        {
            StartTransaction();
            var emp = await FindByEmail(email);
            if (emp is null)
            {
                throw new Exception("Employee not exist!");
            }
            PasswordHasheHelper helper = new();
            if (!helper.VerifyPassword(emp.Password, password))
            {
                throw new Exception("Password incorrect");
            }
            return emp;
        }
        public async Task<Employee> AddOne(Employee emp)
        {
            StartTransaction();
            var entity = (await Context.Employees.AddAsync(emp)).Entity;
            Context.SaveChanges();
            return entity;
        }
        public bool AnyEmployeesExist()
        {
            StartTransaction();
            return Context.Employees.Any();
        }
    }
}
