using Store_Management.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management.ViewModels.EmployeeVM
{
    public class LoginVM : ViewModelBase
    {

        private string _email;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand RelayCommand { get; set; } = new RelayCommand((obj) => Navigator.INSTANCE.OpenDialog(new SignupVM()));
    }
}
