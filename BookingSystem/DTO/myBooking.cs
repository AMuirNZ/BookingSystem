using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.DTO
{
    public class myBooking
    {
        public int Id { get; set; }
        public int PerformanceId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int NumberFullPrice { get; set; }
        public int NumberConcessionPrice { get; set; }
        public bool StoreEmail { get; set; }
        public decimal TotalCost { get; set; }
    }
}
