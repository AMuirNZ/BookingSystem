using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Models;

namespace BookingSystem.DTO
{
    public class BookingSystemDTO
    {
        public List<Booking> bookings = new List<Booking>();
        public List<Seat> seats = new List<Seat>();

        public myBooking myBooking { get; set; }
        public mySeat mySeat { get; set; }


    }
}
