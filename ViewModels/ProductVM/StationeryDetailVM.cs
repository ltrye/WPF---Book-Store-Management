using Store_Management.Data.Models;
using Store_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management.ViewModels.ProductVM
{
    public class StationeryDetailVM : ViewModelBase
    {
        private StoreDbContext Context { get; }
        private Stationery _stationery;

        public Stationery Stationery{ get { return _stationery; } set { _stationery = value; OnPropertyChanged(); } }

        public StationeryDetailVM(int stationeryId)
        {
            Context = new StoreDbContext();

            Init(stationeryId);
        }

        private async void Init(int bookId)
        {
            Stationery = await Context.Stationeries.FindAsync(bookId);
        }
    }
}
