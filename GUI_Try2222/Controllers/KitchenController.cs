using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GUI_Try2222.Data;
using Microsoft.AspNetCore.Authorization;
using System.Dynamic;
using GUI_Try2222.Models;

namespace GUI_Try2222.Controllers
{
    //[Authorize(Roles = "Restaurant")]
    public class KitchenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitchenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Kitchen
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            MappedAllData model = new MappedAllData();
            model.expectexArrival = _context.ExpectedArrival.ToList();
            model.booking = _context.Booking.ToList();

            return View(model);
        }


        //// GET: Kitchen/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var booking = await _context.ExpectedArrival
        //        .FirstOrDefaultAsync(m => m.AdjustId == id);
        //    if (booking == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(booking);
        //}

        
        public IActionResult CookingDetails(string myDate)
        {
            MappedAllData model = new MappedAllData();
            model.expectexArrival = _context.ExpectedArrival.ToList();
            model.booking = _context.Booking.ToList();
            if (myDate == null)
            {
                model.NewDate = DateTime.Today;
            }
            else
            {
                model.NewDate = DateTime.Parse(myDate);
            }

            if (myDate == null)
            {
                //return View(model.expectexArrival.Where(o => o.ExpenseDate == DateTime.Today));
                return View(model);
            }
            else
            {
                //return View(model.expectexArrival.Where(o => o.ExpenseDate == DateTime.Parse(myDate)));
                return View(model);
            }
        }


        //// GET: Kitchen/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Kitchen/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Adults,Children,ExpenseDate")] ExpectedArrival booking)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(booking);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(booking);
        //}

        //// GET: Kitchen/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var booking = await _context.ExpectedArrival.FindAsync(id);
        //    if (booking == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(booking);
        //}

        //// POST: Kitchen/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Adults,Children,ExpenseDate")] ExpectedArrival booking)
        //{
        //    if (id != booking.AdjustId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(booking);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BookingExists(booking.AdjustId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(booking);
        //}

        //// GET: Kitchen/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var booking = await _context.ExpectedArrival
        //        .FirstOrDefaultAsync(m => m.AdjustId == id);
        //    if (booking == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(booking);
        //}

        //// POST: Kitchen/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var booking = await _context.ExpectedArrival.FindAsync(id);
        //    _context.ExpectedArrival.Remove(booking);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool BookingExists(int id)
        //{
        //    return _context.ExpectedArrival.Any(e => e.AdjustId == id);
        //}
    }
}
