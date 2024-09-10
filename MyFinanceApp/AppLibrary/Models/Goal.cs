using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary.Models
{
    public class Goal
    {
        public int Goal_id { get; set; }
        public int User_id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Begin_date { get; set; }
        public DateTime End_date { get; set; }
        public decimal Amount { get; set; }
        public decimal Goal_Amount { get; set; }
    }
}
