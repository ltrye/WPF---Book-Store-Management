using Store_Management.Data;
using Store_Management.Data.Models;
using Store_Management.Services;
using Store_Management.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management.ViewModels.ProductVM
{
    public class ListProductVM : ViewModelBase
    {
        private Navigator Navigator { get; }
        private ProductService _productService;
        private BookService BookService;

        private ObservableCollection<Product> _products;
        private ObservableCollection<Book> _books;

        private Product _selectedProduct;

        
        #region Properties
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Book> Books { get => _books; set => SetProperty(ref _books, value); }

        #endregion

        public ListProductVM()
        {
            Navigator = Navigator.INSTANCE;
            BookService = new BookService();
            _productService = new ProductService();
            ShowProductDetailsCommand = new RelayCommand(async (obj) => await ShowProductDetails(), (obj) => SelectedProduct != null);
            GoToAddBookCmd = new RelayCommand(obj => GoToAddBook());

            //Init
            Task t = Init();
        }

        public async Task Init()
        {
            await LoadDataList();
        }

        public async Task LoadDataList()
        {
            var productsList = await BookService.FindAllBook();
            Products = new ObservableCollection<Product>(productsList);
        }

        public async Task ShowProductDetails()
        {
            //Navigator.INSTANCE.NavigateTo(new ProductDetailVM(SelectedProduct.Id));
            if (SelectedProduct is Book book)
            {
                Navigator.ToUpdateBook(book.Id);

            }
            else if (SelectedProduct is Stationery)
            {
                Navigator.INSTANCE.OpenDialog(new StationeryDetailVM(SelectedProduct.Id));
            }
            await LoadDataList();

        }

        public async void GoToAddBook()
        {
            Navigator.ToAddBook();
            await LoadDataList();
        }




        public RelayCommand ShowProductDetailsCommand { get; set; }
        public RelayCommand GoToAddBookCmd { get; set; }

    }
}
