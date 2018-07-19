using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingSystem.Data;
using BookingSystem.Models;
using BookingSystem.DTO;
using BookingSystem.Operations;
namespace BookingSystem.Controllers

{
    public class PerformancesController : Controller
    {
        private readonly BookingContext _context;

        public PerformancesController(BookingContext context)
        {
            _context = context;
        }

        // GET: Performances
        public async Task<IActionResult> Index()
        {
            return View(await _context.Performances.ToListAsync());
        }

        // GET: Performances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performances = await _context.Performances
                .SingleOrDefaultAsync(m => m.Id == id);

            BookingSystemDTO bookingsystemdto = new BookingSystemDTO();
            myPerformance myPerformances = new myPerformance();

            DatabaseManager.PerformanceId = performances.Id;

            DatabaseManager.ShowId = performances.ShowId;








            var allperformances = _context.Performances.ToList();
            bookingsystemdto.performances = allperformances;


            bookingsystemdto.myPerformances = myPerformances;

            if (performances == null)
            {
                return NotFound();
            }

            return View(performances);
        }

        // GET: Performances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Performances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ShowId,Date")] Performances performances)
        {
            if (ModelState.IsValid)
            {
                _context.Add(performances);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(performances);
        }

        // GET: Performances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performances = await _context.Performances.SingleOrDefaultAsync(m => m.Id == id);
            if (performances == null)
            {
                return NotFound();
            }
            return View(performances);
        }

        // POST: Performances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ShowId,Date")] Performances performances)
        {
            if (id != performances.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(performances);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerformancesExists(performances.Id))
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
            return View(performances);
        }

        // GET: Performances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performances = await _context.Performances
                .SingleOrDefaultAsync(m => m.Id == id);
            if (performances == null)
            {
                return NotFound();
            }

            return View(performances);
        }

        // POST: Performances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var performances = await _context.Performances.SingleOrDefaultAsync(m => m.Id == id);
            _context.Performances.Remove(performances);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerformancesExists(int id)
        {
            return _context.Performances.Any(e => e.Id == id);
        }
    }
}
