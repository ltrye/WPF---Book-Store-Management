using Microsoft.EntityFrameworkCore;
using Store_Management.Data;
using Store_Management.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;


namespace Store_Management.Services
{
    public class ProductService
    {
        private StoreDbContext _context;


        public ProductService(StoreDbContext context)
        {
            _context = context;

        }
        public ProductService()
        {
            _context = new StoreDbContext();

        }
        public async Task<List<Product>> GetListOfProducts()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();

            return products;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var products = await _context.Books.Include(p => p.Category).ToListAsync();
            return products;
        }


        public async Task<Product> FindById(int id)
        {
            var product = await _context.Products.Include(p => p.Category).Where(p => p.Id == id).FirstOrDefaultAsync();
            return product;
        }

        public async Task AddBook(Book book)
        {
            book.CreatedDate = DateTime.Now;
            book.CreatedBy = 1;
            await _context.AddAsync(book);
            _context.SaveChanges();

        }
        public async Task<bool> UpdateBook(Book book)
        {
            try
            {
                book.UpdatedDate = DateTime.Now;
                book.UpdatedBy = 1;
                _context.Books.Update(book);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> UpdateStationeryById(Stationery product)
        {
            try
            {

                _context.Stationeries.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task DeleteProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                product.IsActive = false;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Product with ID {id} not found.");
            }

        }
    }
}