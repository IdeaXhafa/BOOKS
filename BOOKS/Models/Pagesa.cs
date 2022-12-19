using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKS.Models
{
    public class Pagesa
    {
        public int id { get; set; }
        public int Shuma { get; set; }
        public bool Active { get; set; }
        public DateTime DataEPageses { get; set; }

        public DateTime DataESkadimit { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}
