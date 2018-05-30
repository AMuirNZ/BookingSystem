using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingSystem.Data;
using BookingSystem.Models;

namespace BookingSystem.Controllers
{
    public class ShowsController : Controller
    {
        private readonly BookingContext _context;

        public ShowsController(BookingContext context)
        {
            _context = context;
        }

        // GET: Shows
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shows.ToListAsync());
        }

        // GET: Shows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shows = await _context.Shows
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shows == null)
            {
                return NotFound();
            }

            return View(shows);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EndDate,FullPrice,ConcessionPrice")] Shows shows)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shows);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shows);
        }

        // GET: Shows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shows = await _context.Shows.SingleOrDefaultAsync(m => m.Id == id);
            if (shows == null)
            {
                return NotFound();
            }
            return View(shows);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EndDate,FullPrice,ConcessionPrice")] Shows shows)
        {
            if (id != shows.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shows);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowsExists(shows.Id))
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
            return View(shows);
        }

        // GET: Shows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shows = await _context.Shows
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shows == null)
            {
                return NotFound();
            }

            return View(shows);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shows = await _context.Shows.SingleOrDefaultAsync(m => m.Id == id);
            _context.Shows.Remove(shows);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowsExists(int id)
        {
            return _context.Shows.Any(e => e.Id == id);
        }
    }
}
