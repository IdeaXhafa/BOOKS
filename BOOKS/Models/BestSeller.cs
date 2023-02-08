using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKS.Models
{
    public class BestSeller
    {
        public int id { get; set; }
        public string Titulli { get; set; }
        public string Autori { get; set; }
        public int Rating { get; set; }
        public DateTime Year { get; set; }
    }
}