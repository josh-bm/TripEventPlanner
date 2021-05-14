using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripEventPlanner.Data;
using TripEventPlanner.Models;

namespace TripEventPlanner.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ItravelPlannerDBContext _context;

        public ActivitiesController(ItravelPlannerDBContext context)
        {
            _context = context;
        }

        //GET: Activities
        //public async Task<IActionResult> Index()
        //{
          //  var itravelPlannerDBContext = _context.Activities.Include(a => a.ActivityType).Include(a => a.Location);
        //    return View(await itravelPlannerDBContext.ToListAsync());
        //}

        public IActionResult Index(string option, string search)
        {
            var itravelPlannerDBContext = _context.Activities.Include(a => a.ActivityType).Include(a => a.Location);
            if (option == "Activity")
            {
                return View(_context.Activities
                    .Where(x => x.ActivityType.Name == search || search == null).ToList());
            }
            else if (option == "Location")
            {
                return View(_context.Activities
                    .Where(x => x.Location.Name == search || search == null).ToList());
            }
            else
            {
                return View(itravelPlannerDBContext.Where(x => x.Name.StartsWith(search) || search == null).ToList());
            }

            // declare the list
            // List<SelectListItem> activityTypes = new List<SelectListItem>();
            //List<SelectListItem> locations = new List<SelectListItem>();

            // generate the dropdown list
            // foreach (Activity activities in _context.Activities.Include(a => a.ActivityType).Include(a => a.Location))
            // {
            //   activityTypes.Add(new SelectListItem
            //   {
            //       Text = activities.ActivityType.Name,
            //  Value = activities.ActivityType.Name.ToString()
            //  });
            //}

            //return View();
        }

        //[HttpPost]
        //public IActionResult Index(short? activityId)
        //{
        //}

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .Include(a => a.ActivityType)
                .Include(a => a.Location)
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            ViewData["ActivityTypeId"] = new SelectList(_context.ActivityTypes, "ActivityTypeId", "Name");
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Name");
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActivityId,Name,Description,Address,Price,ActivityTypeId,ImageUrl,StartDate,EndDate,LocationId")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityTypeId"] = new SelectList(_context.ActivityTypes, "ActivityTypeId", "Name", activity.ActivityTypeId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Name", activity.LocationId);
            return View(activity);
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            ViewData["ActivityTypeId"] = new SelectList(_context.ActivityTypes, "ActivityTypeId", "Name", activity.ActivityTypeId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Name", activity.LocationId);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("ActivityId,Name,Description,Address,Price,ActivityTypeId,ImageUrl,StartDate,EndDate,LocationId")] Activity activity)
        {
            if (id != activity.ActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityExists(activity.ActivityId))
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
            ViewData["ActivityTypeId"] = new SelectList(_context.ActivityTypes, "ActivityTypeId", "Name", activity.ActivityTypeId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "Name", activity.LocationId);
            return View(activity);
        }

        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .Include(a => a.ActivityType)
                .Include(a => a.Location)
                .FirstOrDefaultAsync(m => m.ActivityId == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var activity = await _context.Activities.FindAsync(id);
            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityExists(short id)
        {
            return _context.Activities.Any(e => e.ActivityId == id);
        }
    }
}