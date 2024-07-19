using Microsoft.EntityFrameworkCore;
using Store_Management.Data;
using Store_Management.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management.Services
{
    public class AuthorService
    {
        private StoreDbContext Context { get; set; }

        public async Task<List<Author>> GetAll()
        {
            using (Context = new StoreDbContext())
            {
                return await Context.Authors.ToListAsync();
            }
        }
    }
}
