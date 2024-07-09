using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Store_Management.ViewModels.Utils
{
    public class Navigator
    {
        public static Navigator INSTANCE { get; private set; }
        private NavigationPanelVM _navigationVM { get; set; }

        public Window HostWindow { get; }
        public Navigator(NavigationPanelVM viewModel, Window hostWindow)
        {
            _navigationVM = viewModel;
            HostWindow = hostWindow;    
        }


        public void NavigateTo(ViewModelBase vm)
        {
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

        public static void CreateInstance(NavigationPanelVM viewModel, Window host)
        {
            INSTANCE = new Navigator(viewModel, host);
        }

    }
}
