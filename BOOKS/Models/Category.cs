using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKS.Models
{    
    public class Category
    {
        public int id { get; set; }
        public string CategoryName { get; set; }
    }
}