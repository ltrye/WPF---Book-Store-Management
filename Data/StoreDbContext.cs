using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store_Management.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management.Data
{
    public class StoreDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Stationery> Stationeries { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<KPIRecord> KPIRecords { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleDetail> SaleDetails { get; set; }



        public StoreDbContext()
        {

        }
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional:true)
               .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("StoreDbContext"));
            optionsBuilder.LogTo((msg) => Debug.WriteLine(msg));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>()
                .HasOne(cate => cate.Parent)
                .WithMany(cate => cate.SubCategories)
                .HasForeignKey(cate => cate.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
                .ToTable("Books");
            modelBuilder.Entity<Stationery>()
                .ToTable("Stationeries");

            modelBuilder.Entity<Brand>()
                .HasData(
                new Brand
                {
                    Id = 1,
                    Name = "LTCompany",
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    CreatedBy = 1
                }
                );
            modelBuilder.Entity<Author>()
                .HasData(
                    new Author
                    {
                        Id = 1,
                        Name ="Le Trung Ha",
                        CreatedDate = DateTime.Now,
                        CreatedBy = 1
                    }
                );
            modelBuilder.Entity<Publisher>()
                .HasData(
                 new Publisher
                 {
                     Id = 1,
                     Name="NXB Kim Dong",
                     CreatedBy =1,
                     CreatedDate = DateTime.Now,
                 }
                );

            modelBuilder.Entity<Category>().HasData(
       new Category { Id = 1, Name = "Books" },
       new Category { Id = 2, Name = "Stationery" },
       new Category { Id = 3, Name = "Office Supplies" }
   );

            modelBuilder.Entity<Book>().HasData(
                   new Book
                   {
                       Id = 1,
                       PublisherId = 1,
                       ISBN = "BK235",
                       AuthorId = 1,
                       PublicationYear = 2025,
                       Name = "The Great Gatsby",
                       Description = "Classic novel by F. Scott Fitzgerald",
                       CategoryId = 1,
                       Price = 10.99m,
                       IsActive = true,
                       ImageUrl = "the_great_gatsby.jpg",
                       CreatedBy = 1,
                       CreatedDate = DateTime.Now

                   }, 
                   new Book
                   {
                       Id = 2,
                       PublisherId = 1,
                       ISBN = "BK235",
                       AuthorId = 1,
                       PublicationYear = 2025,
                       Name = "1984",
                       Description = "Dystopian novel by George Orwell",
                       CategoryId = 1,
                       Price = 10.99m,
                       IsActive = true,
                       ImageUrl = "1984.jpg",
                       CreatedBy = 1,
                       CreatedDate = DateTime.Now

                   }

                );
            modelBuilder.Entity<Stationery>().HasData(
           new Stationery
           {
               Id = 3,
               BrandId = 1,
               Name = "To Kill a Mockingbird",
               Description = "Novel by Harper Lee",
               CategoryId = 1,
               Price = 7.99m,
               IsActive = true,
               ImageUrl = "to_kill_a_mockingbird.jpg",
               CreatedBy = 1,
               CreatedDate = DateTime.Now
           },
           new Stationery
           {
               Id = 4,
               BrandId = 1,
               Name = "A4 Notebook",
               Description = "100-page A4 notebook",
               CategoryId = 2,
               Price = 2.50m,
               IsActive = true,
               ImageUrl = "a4_notebook.jpg",
               CreatedBy = 1,
               CreatedDate = DateTime.Now
           },
           new Stationery
           {
               Id = 5,
               BrandId = 1,
               Name = "Ballpoint Pen",
               Description = "Blue ballpoint pen",
               CategoryId = 2,
               Price = 0.99m,
               IsActive = true,
               ImageUrl = "ballpoint_pen.jpg",
               CreatedBy = 1,
               CreatedDate = DateTime.Now
           },
           new Stationery
           {
               Id = 6,
               BrandId = 1,
               Name = "Highlighter Set",
               Description = "Set of 5 highlighters",
               CategoryId = 2,
               Price = 5.49m,
               IsActive = true,
               ImageUrl = "highlighter_set.jpg",
               CreatedBy = 1,
               CreatedDate = DateTime.Now
           },
           new Stationery
           {
               Id = 7,
               BrandId = 1,
               Name = "Sticky Notes",
               Description = "Pack of sticky notes",
               CategoryId = 2,
               Price = 1.99m,
               IsActive = true,
               ImageUrl = "sticky_notes.jpg",
               CreatedBy = 1,
               CreatedDate = DateTime.Now
           },
           new Stationery
           {
               Id = 8,
               BrandId = 1,
               Name = "Desk Organizer",
               Description = "Office desk organizer",
               CategoryId = 3,
               Price = 12.99m,
               IsActive = true,
               ImageUrl = "desk_organizer.jpg",
               CreatedBy =1,
               CreatedDate = DateTime.Now
           },
           new Stationery
           {
               Id = 9,
               BrandId = 1,
               Name = "File Folders",
               Description = "Set of 10 file folders",
               CategoryId = 3,
               Price = 9.99m,
               IsActive = true,
               ImageUrl = "file_folders.jpg",
               CreatedBy = 1,
               CreatedDate = DateTime.Now
           },
           new Stationery
           {
               Id = 10,
               BrandId = 1,
               Name = "Printer Paper",
               Description = "Ream of A4 printer paper",
               CategoryId = 3,
               Price = 4.99m,
               IsActive = true,
               ImageUrl = "printer_paper.jpg",
               CreatedBy = 1,
               CreatedDate = DateTime.Now
           });
  

        }
    }
}
