using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management.Data.Models
{
    public class SaleDetail : EntityBase
    {
        [Required]
        public int ProductId {  get; set; }
        [Required]
        public int SaleId {  get; set; }

        public Product? Product { get; set; }
        public Sale? Sale { get; set; }
        [Required]
        public int quantity { get; set; }



    }
}
