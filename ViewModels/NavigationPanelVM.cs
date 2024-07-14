using Store_Management.Data.Models;
using Store_Management.Utils;
using Store_Management.ViewModels.ProductVM;
using Store_Management.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management.ViewModels
{
    public class NavigationPanelVM : NavigatableViewModel
    {

        private Employee _currentEmployee;
        public string StoreName { get; set; } = "LTH Book Store";


        private ObservableCollection<NavigationItem> _navigationItems;

        #region Properties

        public Employee CurrentEmployee { get => _currentEmployee; set => SetProperty(ref _currentEmployee, value);}
        public ObservableCollection<NavigationItem> NavigationItems
        {
            get { return _navigationItems; }
            set { _navigationItems = value; OnPropertyChanged(); }
        }

        #endregion

        public NavigationPanelVM()
        {
            Navigator.INSTANCE.RegisterNavigationViewModel(this);


            NavigationItems = new ObservableCollection<NavigationItem>
            {
                new("Home", new HomeVM(), isActive: true),
                new("Products Management", new ListProductVM())
            };

            //Employee
            CurrentEmployee = StoreSession.Instance.ActiveEmployee;

            //Inital page
            CurrentPage = new HomeVM();
        }


    }



    public struct NavigationItem
    {
        public NavigationItem(string name, ViewModelBase viewModel, bool isActive = false)
        {
            this.Name = name;
            this.Command = new RelayCommand((obj) => Navigator.INSTANCE.NavigateTo(viewModel));
            this.IsActive = isActive;
        }
        public bool IsActive {  get; set; }
        public string Name { get; set; }
        public RelayCommand Command { get; set; }
    }
}

