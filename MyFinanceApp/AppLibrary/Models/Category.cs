using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.Models
{
    public class Category
    {
        public int Category_id { get; set; }
        public string? Type { get; set; }
        public int Budget_id { get; set; }
        public int Transaction_id { get; set; }
    }
}
