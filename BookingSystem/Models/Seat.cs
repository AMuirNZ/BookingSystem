using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public string SeatNumber { get; set; }

    }
}
