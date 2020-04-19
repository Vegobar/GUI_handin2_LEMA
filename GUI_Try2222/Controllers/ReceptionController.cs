using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GUI_Try2222.Data;
using Microsoft.AspNetCore.Authorization;

namespace GUI_Try2222.Controllers
{
    [Authorize(Roles = "Reception")]
    public class ReceptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceptionController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: ExpectedArrivals
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpectedArrival.ToListAsync()); 
        }
        
     
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Adults,Children,ExpenseDate")] ExpectedArrival expectedArrival)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expectedArrival);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expectedArrival);
        }

        // GET: Reception/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrivals = await _context.ExpectedArrival
                .FirstOrDefaultAsync(m => m.AdjustId == id);
            if (arrivals == null)
            {
                return NotFound();
            }

            return View(arrivals);
        }

        // POST: Reception/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arrivals = await _context.ExpectedArrival.FindAsync(id);
            _context.ExpectedArrival.Remove(arrivals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpectedArrivalExists(int id)
        {
            return _context.ExpectedArrival.Any(e => e.AdjustId == id);
        }

        // GET: Reception/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expectedArrival = await _context.ExpectedArrival.FindAsync(id);
            if (expectedArrival == null)
            {
                return NotFound();
            }
            return View(expectedArrival);
        }

        // POST: Reception/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Adults,Children")] ExpectedArrival expectedArrival)
        {
            if (id != expectedArrival.AdjustId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expectedArrival);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                    if (!ExpectedArrivalExists(expectedArrival.AdjustId))
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
            return View(expectedArrival);
        }

        // GET: Reception/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arrival = await _context.ExpectedArrival
                .FirstOrDefaultAsync(m => m.AdjustId == id);
            if (arrival == null)
            {
                return NotFound();
            }

            return View(arrival);
        }

    }
}