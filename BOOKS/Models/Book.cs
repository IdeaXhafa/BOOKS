using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKS.Models
{
    public class Book
    {
        public int id { get; set; }

        [Required]
        public string Titulli { get; set; }
        public string Autori { get; set; }
        public int huazime { get; set; }
        public bool E_Lire { get; set; }
    }
}
