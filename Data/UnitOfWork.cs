using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management.Data
{
    public class UnitOfWork : IDisposable
    {
        private readonly StoreDbContext _context;


        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
           
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
