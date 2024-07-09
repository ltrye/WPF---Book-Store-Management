using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management.Data.Models
{
    public class Product : EntityBase
    {
        public Product() { }

        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }
        [Required]
        public Category? Category { get; set; }

        [Required]
        [Column(TypeName = "decimal(20,0)")]
        public decimal Price { get; set; }
        public string? ImageUrl {  get; set; }
    }
}
