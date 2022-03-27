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
    public class ContatctusController : Controller
    {
        private readonly ModelContext _context;

        public ContatctusController(ModelContext context)
        {
            _context = context;
        }

        // GET: Contatctus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contatctus.ToListAsync());
        }

        // GET: Contatctus/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatctu = await _context.Contatctus
                .FirstOrDefaultAsync(m => m.ContatcusId == id);
            if (contatctu == null)
            {
                return NotFound();
            }

            return View(contatctu);
        }

        // GET: Contatctus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contatctus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContatcusId,Email,FirstName,PhoneNumber,Message")] Contatctu contatctu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contatctu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contatctu);
        }

        // GET: Contatctus/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatctu = await _context.Contatctus.FindAsync(id);
            if (contatctu == null)
            {
                return NotFound();
            }
            return View(contatctu);
        }

        // POST: Contatctus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("ContatcusId,Email,FirstName,PhoneNumber,Message")] Contatctu contatctu)
        {
            if (id != contatctu.ContatcusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contatctu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatctuExists(contatctu.ContatcusId))
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
            return View(contatctu);
        }

        // GET: Contatctus/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contatctu = await _context.Contatctus
                .FirstOrDefaultAsync(m => m.ContatcusId == id);
            if (contatctu == null)
            {
                return NotFound();
            }

            return View(contatctu);
        }

        // POST: Contatctus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var contatctu = await _context.Contatctus.FindAsync(id);
            _context.Contatctus.Remove(contatctu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Contact()
        {
            return View(await _context.Contatctus.ToListAsync());
        }
        private bool ContatctuExists(decimal id)
        {
            return _context.Contatctus.Any(e => e.ContatcusId == id);
        }
    }
}
