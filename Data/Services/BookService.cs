using Microsoft.EntityFrameworkCore;
using Store_Management.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management.Data.Services
{
    public class BookService
    {
        private StoreDbContext Context { get; set; }
        public BookService()
        {
            Context = new StoreDbContext();
        }

        public async Task<Book?> FindBookById(int id)
        {
            using (Context = new StoreDbContext())
            {

                return await Context.Books
                    .Include(book => book.Category)
                    .Include(book => book.Publisher)
                    .Include(book => book.Author)
                    .FirstOrDefaultAsync(book => book.Id == id);
            }
        }

        public async Task<List<Book>> FindAllBook()
        {
            using (Context = new StoreDbContext())
            {

                return await Context.Books
                    .Include(book => book.Category)
                    .Include(book => book.Publisher)
                    .Include(book => book.Author)
                    .ToListAsync();
            }
        }
        public async Task<bool> AddBook(Book book)
        {
            using (Context = new StoreDbContext())
            {

                Context.Books.Add(book);
                return await Context.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> UpdateBook(Book book)
        {
            using (Context = new StoreDbContext())
            {

                Context.Update(book);
                return await Context.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> DeleteBook(Book book)
        {
            using (Context = new StoreDbContext())
            {

                Book? check = await Context.Books.FindAsync(book.Id);
                if (check == null) { throw new Exception("Book not found!"); }

                Context.Books.Remove(book);
                return await Context.SaveChangesAsync() > 0;
            }

        }
    }
}
