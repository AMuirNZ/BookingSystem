using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Models
{
    public class Shows
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EndDate { get; set; }  
        public Decimal FullPrice { get; set; }
        public Decimal ConcessionPrice { get; set; }

    }
}
