using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKS.Models
{
    public class Klienti
    {

        public int id { get; set; }

        [Required]
        public string Emri { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string NumriTel { get; set; }
        public bool Aktiv { get; set; }
        public DateTime created_at { get; set; }
        public DateTime deleted_at { get; set; }
        // public ICollection<Pagesa> Pagesa { get; set; }
    }
}