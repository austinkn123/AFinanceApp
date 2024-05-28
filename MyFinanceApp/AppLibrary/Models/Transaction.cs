using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.Models
{
    public class Transaction
    {
        public int Transaction_id { get; set; }
        public DateTime Transaction_date { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }
}
