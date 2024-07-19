using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    public class SaleService
    {
        CustomerService CustomerService = new CustomerService();

        private StoreDbContext Context { get; set; }

        public int CalculateTotalPrice(List<SaleItem> items)
        {
            int TotalPrice = 0;
            foreach (var item in items)
            {
                TotalPrice += (int)item.Book.Price * item.quantity;
            }
            return TotalPrice;
        }
        public async Task AddTransaction(Sale sale, String? customerPhone, String? customerName)
        {

            if(sale.SaleDetails.IsNullOrEmpty()) { throw new Exception("Please item for checkout!"); }

            int? customerId = null;
            if (customerPhone != null)
            {
                var customer = await CustomerService.GetByPhone(customerPhone);
                if (customer == null)
                {
                    Customer customer1 = new Customer { PhoneNumber = customerPhone, FullName = customerName };
                    await CustomerService.Create(customer1);
                    sale.CustomerId = customer1.Id;
                }
                else
                {

                    sale.CustomerId = customer.Id;
                }
            }

            using (Context = new StoreDbContext())
            {


                sale.CreatedBy = StoreSession.Instance.ActiveEmployee.Id;
                sale.CreatedDate = DateTime.Now;
                sale.SaleDetails = sale.SaleDetails.Select(i => new SaleItem
                {
                    BookId = i.Book.Id,
                    Book = null,
                    CreatedBy = StoreSession.Instance.ActiveEmployee.Id,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    quantity = i.quantity,


                }).ToList();

                Context.Sales.Add(sale);


                foreach (var item in sale.SaleDetails)
                {
                    var book = await Context.Books.FindAsync(item.BookId);
                    book.Stock -= item.quantity;
                    if (book.Stock < 0)
                    {
                        throw new Exception($"Error: Book with id {book.Id} is out of stock");
                    }
                    // Attach the book to the context
                    Context.Books.Attach(book);

                    // Mark the Stock property as modified
                    Context.Entry(book).Property(b => b.Stock).IsModified = true;

                }


                await Context.SaveChangesAsync();


            }
        }

        public async Task<List<Sale>> GetAll()
        {
            using (Context = new StoreDbContext())
            {
                return await Context.Sales.Include(s => s.Customer).ToListAsync();
            }
        }
    }
}
