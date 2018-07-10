using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.DTO
{
    public class myShow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EndDate { get; set; }
        public Decimal FullPrice { get; set; }
        public Decimal ConcessionPrice { get; set; }
    }
}
