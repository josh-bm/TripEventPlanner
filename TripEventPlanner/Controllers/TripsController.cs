using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripEventPlanner.Data;
using TripEventPlanner.Models;
using TripEventPlanner.Models.ViewModels;

namespace TripEventPlanner.Controllers {
    public class TripsController : Controller {
        private readonly ItravelPlannerDBContext _context;

        public TripsController( ItravelPlannerDBContext context ) {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index( int id ) {

            var itravelPlannerDBContext = _context.Trips.Where(t => t.UserId == id)
                .Include(a => a.Country)
                .ThenInclude(c => c.Locations)
                .ThenInclude(m => m.Activities);

            return View(await itravelPlannerDBContext.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details( short? id ) {
            if( id == null ) {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TripId == id);
            if( trip == null ) {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create() {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( [Bind("TripId,Name,StartDate,EndDate,UserId")] Trip trip ) {
            if( ModelState.IsValid ) {
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", trip.UserId);
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit( short? id ) {
            if( id == null ) {
                return NotFound();
            }

            var trip = await _context.Trips.FindAsync(id);
            if( trip == null ) {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", trip.UserId);
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( short id, [Bind("TripId,Name,StartDate,EndDate,UserId")] Trip trip ) {
            if( id != trip.TripId ) {
                return NotFound();
            }

            if( ModelState.IsValid ) {
                try {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch( DbUpdateConcurrencyException ) {
                    if( !TripExists(trip.TripId) ) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", trip.UserId);
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete( short? id ) {
            if( id == null ) {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TripId == id);
            if( trip == null ) {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed( short id ) {
            var trip = await _context.Trips.FindAsync(id);
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists( short id ) {
            return _context.Trips.Any(e => e.TripId == id);
        }
    }
}