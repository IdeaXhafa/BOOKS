using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKS.Models
{
    public class Magazines
    {

        public int id { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string description { get; set; }
    }
}