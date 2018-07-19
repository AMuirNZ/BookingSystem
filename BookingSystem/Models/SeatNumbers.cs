using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Models
{
    public class SeatNumbers
    {
        public int Id { get; set; }
        public int showId { get; set; }
        public string SeatNumber { get; set; }
        public bool isSeatAvailable { get; set; }

    }
}
