using Store_Management.Data.Models;
using Store_Management.Services;
using Store_Management.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Store_Management.ViewModels.EmployeeVM
{
    public class EmployeeDetailsVM : ViewModelBase
    {


        private EmployeeService EmployeeService { get; set; }
        public Employee.Role AccessLevel { get; set; }

        //Role
        public Array RoleList { get; } = RoleUtil.ToArray();


        public bool IsRoleEditable { get; set; }
        public bool IsActiveEditable { get; set; }
        public string RoleDisplay { get; set; }

        private string _statusDisplay;

        private Employee.Role _role;
        //Input field
        private int? _employeeId;
        private string? _fullName;
        private string? _email;
        private int _roleId;
        private string? _citizenId;
        private int? _age;
        private string? _address;
        private string? _profileImage;
        private bool _isActive;
        private string _phoneNumber;

        #region Properties
        public int? EmployeeId { get => _employeeId; set => SetProperty(ref _employeeId, value); }
        public Employee.Role SelectedRole { get => _role; set => SetProperty(ref _role, value); }
        public string StatusDisplay { get => _statusDisplay; set => SetProperty(ref _statusDisplay, value); }
        public string PhoneNumber { get => _phoneNumber; set => SetProperty(ref _phoneNumber, value); }
        public string FullName { get => _fullName; set => SetProperty(ref _fullName, value); }
        public string Email { get => _email; set => SetProperty(ref _email, value); }
        public int RoleId { get => _roleId; set => SetProperty(ref _roleId, value); }
        public string? CitizenId { get => _citizenId; set => SetProperty(ref _citizenId, value); }
        public int? Age { get => _age; set => SetProperty(ref _age, value); }
        public string? Address { get => _address; set => SetProperty(ref _address, value); }
        public string? ProfileImage { get => _profileImage; set => SetProperty(ref _profileImage, value); }
        public bool IsActive { get => _isActive; set => SetProperty(ref _isActive, value); }

        #endregion
        public EmployeeDetailsVM(int employeeId)
        {
            EmployeeService = new EmployeeService();

            AccessLevel = (Employee.Role)StoreSession.Instance.ActiveEmployee.RoleId;
            IsActiveEditable = IsRoleEditable = (AccessLevel == Employee.Role.ADMIN);

            UpdateEmployeeCommand = new(async obj => await UpdateEmployee());



            LoadEmployeeData(employeeId);
        }

        public async Task LoadEmployeeData(int employeeId)
        {
            Employee? emp = await EmployeeService.FindById(employeeId);
            if (StoreSession.Instance.ActiveEmployee.Id == emp.Id)
            {
                StoreSession.Instance.ActiveEmployee = emp;
            }


            if (emp == null) { Notification.Error("Employee not found!"); return; }
            this.EmployeeId = emp.Id;
            this.FullName = emp.FullName;
            this.Email = emp.Email;
            this.RoleId = emp.RoleId;
            this.CitizenId = emp.CitizenId;
            this.Age = emp.Age ?? null;
            this.Address = emp.Address;
            this.ProfileImage = emp.ProfileImage;
            this.IsActive = emp.IsActive;
            this.PhoneNumber = emp.PhoneNumber;
            this.SelectedRole = (Employee.Role)emp.RoleId;
            this.StatusDisplay = IsActive ? "Active" : "In Active";
            RoleDisplay = RoleUtil.ToRoleName(this.RoleId);
        }
        public async Task UpdateEmployee()
        {
            try
            {

                Employee emp = new Employee
                {
                    Id = EmployeeId.Value,
                    Address = Address,
                    ProfileImage = ProfileImage,
                    PhoneNumber = PhoneNumber,
                    Age = Age,
                    CitizenId = CitizenId,
                    Email = Email,
                    RoleId = (int)SelectedRole,
                    FullName = FullName,
                    IsActive = IsActive,
                    UpdatedBy = StoreSession.Instance.ActiveEmployee.Id,
                    

                };
                await EmployeeService.Update(emp);
                await LoadEmployeeData(this.EmployeeId.Value);
                Notification.Success("Update details success!");
            }
            catch (Exception ex)
            {
                Notification.Error(ex.ToString());
            }
        }

        //Command
        public RelayCommand UpdateEmployeeCommand { get; set; }
    }

}
