using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Store_Management.ViewModels;
using Store_Management.ViewModels.EmployeeVM;
using Store_Management.ViewModels.ProductVM;
using Store_Management.ViewModels.Utils;
using Store_Management.Views;
using Store_Management.Views.Employee;

namespace Store_Management.Utils
{
    public class Navigator
    {
        public static Navigator INSTANCE { get; private set; } = null!;
        private NavigatableViewModel? _navigationVM { get; set; }

        public Window? HostWindow { get; private set; }
        public Navigator(Window? hostWindow = null)
        {
            if (hostWindow != null)
            {
                HostWindow = hostWindow;
            }
        }

        public enum OpenAction
        {
            DEFAULT,
            CLOSE_CURRENT
        }
        public void NavigateTo(ViewModelBase vm)
        {
            if (_navigationVM is null)
            {
                return;
            }
            _navigationVM.CurrentPage = vm;
        }

        public void OpenDialog(ViewModelBase vm)
        {
            Window window = new Window();
            window.Owner = HostWindow;
            window.Width = HostWindow.Width * 0.8d;
            window.Height = HostWindow.Height * 0.8d;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.Content = vm;
            window.ShowDialog();
        }

        public void OpenEmployeeStartWindow(OpenAction? openAction = OpenAction.DEFAULT)
        {
            EmployeeWindow window = new EmployeeWindow(new EmployeeWindowVM());
            window.Show();
            if (openAction == OpenAction.CLOSE_CURRENT) HostWindow?.Close();
            this.HostWindow = window;

        }

        public void OpenStoreMainWindow(OpenAction? openAction = OpenAction.DEFAULT)
        {
            Window window = new MainWindow(new NavigationPanelVM());
            window.Show();
            if (openAction == OpenAction.CLOSE_CURRENT) HostWindow?.Close();
            this.HostWindow = window;

        }

        public void ToUpdateBook(int id)
        {
            var vm = new BookDetailVM(id);
            Window window = new Window();
            window.Owner = HostWindow;
            window.Content = vm;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        public void ToAddBook()
        {
            var vm = new BookDetailVM();
            Window window = new Window();
            window.Owner = HostWindow;
            window.Content = vm;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }





        public void OpenWindow(ViewModelBase vm)
        {
            var window = new Window();
            window.Content = vm;

            window.Show();
        }

        public void OpenWindow(Window window)
        {
            window.Show();
        }
        public static void CreateInstance(Window? host = null)
        {
            INSTANCE = new Navigator(host);
        }
        public void RegisterNavigationViewModel(NavigatableViewModel vm)
        {
            this._navigationVM = vm;
        }


    }
}
