using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripEventPlanner.Data;
using TripEventPlanner.Models;
using Microsoft.AspNetCore.Http;
using TripEventPlanner.Helpers;

namespace TripEventPlanner.Controllers
{
    public class TripsController : Controller
    {
        private readonly ItravelPlannerDBContext _context;

        public TripsController(ItravelPlannerDBContext context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index(int id)
        {
            //HttpContext.Session.GetInt32
            HttpContext.Session.SetInt32("id", id);

            //var itravelPlannerDBContext = _context.Trips.Include(t => t.Country).Include(t => t.User);
            var itravelPlannerDBContext = _context.Trips.Where(t => t.UserId == id)
               .Include(a => a.Country)
               .ThenInclude(c => c.Locations)
               .ThenInclude(m => m.Activities);

            //var mad = from t in _context.Trips.Where(t => t.UserId == id) select t;
            //mad.ToArray()
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //string json = serializer.Serialize(sb);
            var hej = _context.Trips.Where(t => t.UserId == id)
            .Include(a => a.Country);

            //SessionHelper.SetObjectAsJson(HttpContext.Session, "trip", hej);

            return View(await itravelPlannerDBContext.ToListAsync());
        }

        public IActionResult AddActivity()
        {
            return RedirectToAction("Index", "Activities");
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.Country)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            

            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId" , "Email");
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TripId,Name,StartDate,EndDate,CountryId,UserId")] Trip trip)
        {
            var id = HttpContext.Session.GetInt32("id");
            trip.UserId = Convert.ToInt16(id);
            if (ModelState.IsValid)
            {
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return Redirect("~/Trips/index/" + id);
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Name", trip.CountryId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", trip.UserId);
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Name", trip.CountryId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", trip.UserId);
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("TripId,Name,StartDate,EndDate,CountryId,UserId")] Trip trip)
        {
            if (id != trip.TripId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.TripId))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Name", trip.CountryId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", trip.UserId);
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.Country)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var trip = await _context.Trips.FindAsync(id);
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(short id)
        {
            return _context.Trips.Any(e => e.TripId == id);
        }
    }
}
