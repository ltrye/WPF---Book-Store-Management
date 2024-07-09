using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Management.Data.Models
{
    public class Book : Product
    {
        [Required]
        public int AuthorId {  get; set; }

        [Required]
        public int PublisherId {  get; set; }

        [Required]
        [MaxLength(100)]
        public Author? Author { get; set; }

        [Required]
        [MaxLength(20)]
        public string ISBN { get; set; } = null!;

        [MaxLength(100)]
        public Publisher? Publisher { get; set; }

        public int PublicationYear { get; set; }
    }
}
