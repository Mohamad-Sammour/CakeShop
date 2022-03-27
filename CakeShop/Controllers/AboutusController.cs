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
    public class AboutusController : Controller
    {
        private readonly ModelContext _context;

        public AboutusController(ModelContext context)
        {
            _context = context;
        }

        // GET: Aboutus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aboutus.ToListAsync());
        }

        // GET: Aboutus/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutu = await _context.Aboutus
                .FirstOrDefaultAsync(m => m.AboutusId == id);
            if (aboutu == null)
            {
                return NotFound();
            }

            return View(aboutu);
        }

        // GET: Aboutus/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Aboutus/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Aboutus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AboutusId,Message")] Aboutu aboutu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aboutu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutu);
        }

        // GET: Aboutus/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutu = await _context.Aboutus.FindAsync(id);
            if (aboutu == null)
            {
                return NotFound();
            }
            return View(aboutu);
        }

        // POST: Aboutus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("AboutusId,Message")] Aboutu aboutu)
        {
            if (id != aboutu.AboutusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutuExists(aboutu.AboutusId))
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
            return View(aboutu);
        }

        // GET: Aboutus/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutu = await _context.Aboutus
                .FirstOrDefaultAsync(m => m.AboutusId == id);
            if (aboutu == null)
            {
                return NotFound();
            }

            return View(aboutu);
        }

        // POST: Aboutus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var aboutu = await _context.Aboutus.FindAsync(id);
            _context.Aboutus.Remove(aboutu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ForCustomer()
        {
            return View(await _context.Aboutus.ToListAsync());
        }
        private bool AboutuExists(decimal id)
        {
            return _context.Aboutus.Any(e => e.AboutusId == id);
        }
    }
}
