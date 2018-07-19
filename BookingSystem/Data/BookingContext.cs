using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Data
{
   

        public class BookingContext : DbContext //, IDesignTimeDbContextFactory(EventsContext)
        {

            public BookingContext()
            {

            }


            public BookingContext(DbContextOptions<BookingContext> options) : base(options)
            {

            }



            public DbSet<Booking> Booking { get; set; }
            public DbSet<Performances> Performances { get; set; }
            public DbSet<Seat> Seat { get; set; }
            public DbSet<Shows> Shows { get; set; }
           


    }
    

}
