using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CakeShop.Model;

namespace CakeShop.Controllers
{
    public class TestimoialsController : Controller
    {
        private readonly ModelContext _context;

        public TestimoialsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Testimoials
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Testimoials.Include(t => t.Customer);
            return View(await modelContext.ToListAsync());
        }

        // GET: Testimoials/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimoial = await _context.Testimoials
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(m => m.TestimoialId == id);
            if (testimoial == null)
            {
                return NotFound();
            }

            return View(testimoial);
        }

        // GET: Testimoials/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            return View();
        }

        // POST: Testimoials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestimoialId,TestimoialDate,Message,Ratting,CustomerId")] Testimoial testimoial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testimoial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", testimoial.CustomerId);
            return View(testimoial);
        }

        // GET: Testimoials/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimoial = await _context.Testimoials.FindAsync(id);
            if (testimoial == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", testimoial.CustomerId);
            return View(testimoial);
        }

        // POST: Testimoials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("TestimoialId,TestimoialDate,Message,Ratting,CustomerId")] Testimoial testimoial)
        {
            if (id != testimoial.TestimoialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testimoial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestimoialExists(testimoial.TestimoialId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", testimoial.CustomerId);
            return View(testimoial);
        }

        // GET: Testimoials/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testimoial = await _context.Testimoials
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(m => m.TestimoialId == id);
            if (testimoial == null)
            {
                return NotFound();
            }

            return View(testimoial);
        }

        // POST: Testimoials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var testimoial = await _context.Testimoials.FindAsync(id);
            _context.Testimoials.Remove(testimoial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ForAdmin()
        {
            return View(await _context.Testimoials.ToListAsync());
        }

        public async Task<IActionResult> ForAccountant()
        {
            return View(await _context.Testimoials.ToListAsync());
        }


        private bool TestimoialExists(decimal id)
        {
            return _context.Testimoials.Any(e => e.TestimoialId == id);
        }
    }
}
