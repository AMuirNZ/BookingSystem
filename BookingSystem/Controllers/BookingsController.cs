using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingSystem.Data;
using BookingSystem.DTO;
using BookingSystem.Models;
using BookingSystem.Operations;

namespace BookingSystem.Controllers
{
    public class BookingsController : Controller
    {
        private readonly BookingContext _context;
        //private int  = DatabaseManager.AddressId;

        public BookingsController(BookingContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Booking.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .SingleOrDefaultAsync(m => m.Id == id);

            BookingSystemDTO bookingsystemdto = new BookingSystemDTO();
            myBooking myShows = new myBooking();


            DatabaseManager.BookingId = booking.Id;
            myShows.PerformanceId = booking.PerformanceId;
            myShows.Name = booking.Name;
            myShows.Email = booking.Email;
            myShows.NumberFullPrice = booking.NumberFullPrice;
            myShows.NumberConcessionPrice = booking.NumberConcessionPrice;
            myShows.StoreEmail = booking.StoreEmail;

            myShows.TotalCost = (booking.NumberFullPrice * 30) + (booking.NumberConcessionPrice * 25);


            //DatabaseManager.BookingId = (int)id;

            var allbookings = _context.Booking.ToList();
            bookingsystemdto.bookings = allbookings;


            bookingsystemdto.myBooking = myShows;

            if (booking == null)
            {
                return NotFound();
            }

            return View(bookingsystemdto);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PerformanceId,Name,Email,NumberFullPrice,NumberConcessionPrice,StoreEmail,TotalCost")] Booking booking)
        {
            BookingSystemDTO bookingsystemdto = new BookingSystemDTO();
            myBooking myShows = new myBooking();



            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

           

            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.SingleOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PerformanceId,Name,Email,NumberFullPrice,NumberConcessionPrice,StoreEmail,TotalCost")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking
                .SingleOrDefaultAsync(m => m.Id == id);
          
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.SingleOrDefaultAsync(m => m.Id == id);
            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.Id == id);
        }
    }
}
