using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management.Data.Models
{
    public class Employee : EntityBase 
    {
        public Employee() { }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email {  get; set; }
        [Required]
        public string Password {  get; set; }
        [Required]
        public string Role { get; set; }

    }
}
