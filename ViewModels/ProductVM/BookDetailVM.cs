using Microsoft.EntityFrameworkCore;
using Store_Management.Data;
using Store_Management.Data.Models;
using Store_Management.Services;
using Store_Management.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Store_Management.ViewModels.ProductVM
{
    public class BookDetailVM : ViewModelBase
    {
        //private bool _isUpdateDisabled = true;
  
        private BookService BookService { get; }
        private int _id;
        private int _authorId;
        private int _publisherId;
        private string _ISBN;
        private int _publicationYear;
        private string _title;
        private int _categoryId;
        private string _description;
        private decimal _price;
        private string _imageUrl;
        private bool _isActive;

        #region Properties
        public int Id { get => _id; set => SetProperty(ref _id, value); }
        public string Title { get => _title; set => SetProperty(ref _title, value); }
        public string Description { get => _description; set => SetProperty(ref _description, value); }
        public decimal Price { get => _price; set => SetProperty(ref _price, value); }
        public string ISBN { get => _ISBN; set => SetProperty(ref _ISBN, value); }
        public int PublicationYear { get => _publicationYear; set => SetProperty(ref _publicationYear, value); }
        public int AuthorId { get => _authorId; set => SetProperty(ref _authorId, value); }
        public int PublisherId { get => _publisherId; set => SetProperty(ref _publisherId, value); }
        public int CategoryId { get => _categoryId; set => SetProperty(ref _categoryId, value); }
        public string? ImageUrl { get => _imageUrl; set => SetProperty(ref _imageUrl, value); }
        public bool IsActive { get => _isActive; set => SetProperty(ref _isActive, value); }
        //public bool IsUpdateDisabled { get => _isUpdateDisabled; set => SetProperty(ref _isUpdateDisabled, value); }
        #endregion

        public BookDetailVM(int? bookId = null)
        {

            BookService = new BookService();
            AddBookCommand = new(obj => AddBook());
            UpdateBookCommand = new(obj => UpdateBook());

            if (bookId != null)
            {
                SaveChangeCommand = UpdateBookCommand;
                Id = bookId.Value;
                Task init = LoadBookToUpdateForm();
                return;
            }
            SaveChangeCommand = AddBookCommand;
        }
        public RelayCommand AddBookCommand { get; }
        public RelayCommand UpdateBookCommand { get; }
        public RelayCommand EnableUpdateCmd { get; }

        public RelayCommand SaveChangeCommand { get; set; }


        private async Task LoadBookToUpdateForm()
        {
            Book? book = await BookService.FindBookById(Id);

            if (book == null) return;

            Id = book.Id;
            AuthorId = book.AuthorId;
            PublisherId = book.PublisherId;
            ISBN = book.ISBN;
            PublicationYear = book.PublicationYear;
            Title = book.Name;
            CategoryId = book.CategoryId;
            Description = book.Description;
            Price = book.Price;
            ImageUrl = book.ImageUrl;
            IsActive = book.IsActive;


        }

        private Book BookFromViewModel()
        {
            Book book = new Book
            {
                Id = Id,
                AuthorId = AuthorId,
                PublisherId = PublisherId,
                ISBN = ISBN,
                PublicationYear = PublicationYear,
                Name = Title,
                Description = Description,
                CategoryId = CategoryId,
                Price = Price,
                ImageUrl = ImageUrl,
                IsActive = IsActive,


            };
            return book;
        }
        private async void AddBook()
        {
            try
            {

               bool success = await BookService.AddBook(BookFromViewModel());
                if (!success) { throw new Exception(); }
            }
            catch (Exception ex)
            {
                Notification.Error("Add fail!", "Error");
            }
            Notification.Error("Add book successfully!", "Success");

        }

        private async void UpdateBook()
        {
            bool isSuccess = await BookService.UpdateBook(BookFromViewModel());
            if (isSuccess)
            {
                Notification.Error("Update success!", "Success");

            }
            else
            {
                Notification.Error("Update fail!", "Error");
            }
            await LoadBookToUpdateForm();
        }
    }
}
