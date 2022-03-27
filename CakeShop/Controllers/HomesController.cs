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
    public class HomesController : Controller
    {
        private readonly ModelContext _context;

        public HomesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Homes
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Homes.Include(h => h.Aboutus).Include(h => h.Contactus);
            return View(await modelContext.ToListAsync());
        }

        // GET: Homes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes
                .Include(h => h.Aboutus)
                .Include(h => h.Contactus)
                .FirstOrDefaultAsync(m => m.HomeId == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // GET: Homes/Create
        public IActionResult Create()
        {
            ViewData["AboutusId"] = new SelectList(_context.Aboutus, "AboutusId", "AboutusId");
            ViewData["ContactusId"] = new SelectList(_context.Contatctus, "ContatcusId", "ContatcusId");
            return View();
        }

        // POST: Homes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HomeId,Logo,Slider,AboutusId,ContactusId")] Home home)
        {
            if (ModelState.IsValid)
            {
                _context.Add(home);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AboutusId"] = new SelectList(_context.Aboutus, "AboutusId", "AboutusId", home.AboutusId);
            ViewData["ContactusId"] = new SelectList(_context.Contatctus, "ContatcusId", "ContatcusId", home.ContactusId);
            return View(home);
        }

        // GET: Homes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes.FindAsync(id);
            if (home == null)
            {
                return NotFound();
            }
            ViewData["AboutusId"] = new SelectList(_context.Aboutus, "AboutusId", "AboutusId", home.AboutusId);
            ViewData["ContactusId"] = new SelectList(_context.Contatctus, "ContatcusId", "ContatcusId", home.ContactusId);
            return View(home);
        }

        // POST: Homes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("HomeId,Logo,Slider,AboutusId,ContactusId")] Home home)
        {
            if (id != home.HomeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(home);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeExists(home.HomeId))
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
            ViewData["AboutusId"] = new SelectList(_context.Aboutus, "AboutusId", "AboutusId", home.AboutusId);
            ViewData["ContactusId"] = new SelectList(_context.Contatctus, "ContatcusId", "ContatcusId", home.ContactusId);
            return View(home);
        }

        // GET: Homes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var home = await _context.Homes
                .Include(h => h.Aboutus)
                .Include(h => h.Contactus)
                .FirstOrDefaultAsync(m => m.HomeId == id);
            if (home == null)
            {
                return NotFound();
            }

            return View(home);
        }

        // POST: Homes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var home = await _context.Homes.FindAsync(id);
            _context.Homes.Remove(home);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeExists(decimal id)
        {
            return _context.Homes.Any(e => e.HomeId == id);
        }
    }
}
