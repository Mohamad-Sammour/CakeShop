using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CakeShop.Model;
using Microsoft.AspNetCore.Http;

namespace CakeShop.Controllers
{
    public class PaymentMethodsController : Controller
    {
        private readonly ModelContext _context;

        public PaymentMethodsController(ModelContext context)
        {
            _context = context;
        }

        // GET: PaymentMethods
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.PaymentMethods.Include(p => p.Order);
            return View(await modelContext.ToListAsync());
        }

        // GET: PaymentMethods/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethod = await _context.PaymentMethods
                .Include(p => p.Order)
                .FirstOrDefaultAsync(m => m.VisaId == id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            return View(paymentMethod);
        }

        // GET: PaymentMethods/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId");
            return View();
        }

        // POST: PaymentMethods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisaId,Cvv,Amount,OrderId")] PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentMethod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", paymentMethod.OrderId);
            return View(paymentMethod);
        }

        // GET: PaymentMethods/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", paymentMethod.OrderId);
            return View(paymentMethod);
        }

        // POST: PaymentMethods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("VisaId,Cvv,Amount,OrderId")] PaymentMethod paymentMethod)
        {
            if (id != paymentMethod.VisaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentMethodExists(paymentMethod.VisaId))
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "OrderId", paymentMethod.OrderId);
            return View(paymentMethod);
        }

        // GET: PaymentMethods/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentMethod = await _context.PaymentMethods
                .Include(p => p.Order)
                .FirstOrDefaultAsync(m => m.VisaId == id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            return View(paymentMethod);
        }

        // POST: PaymentMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var paymentMethod = await _context.PaymentMethods.FindAsync(id);
            _context.PaymentMethods.Remove(paymentMethod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ForAdmin()
        {
            String id = "id"; ViewBag.sessionID = HttpContext.Session.GetInt32(id);
            String name = "name"; ViewBag.sessionName = HttpContext.Session.GetString(name);
            return View(await _context.PaymentMethods.ToListAsync());
        }
        public async Task<IActionResult> ForAccountant()
        {
            String id = "id"; ViewBag.sessionID = HttpContext.Session.GetInt32(id);
            String name = "name"; ViewBag.sessionName = HttpContext.Session.GetString(name);
            return View(await _context.PaymentMethods.ToListAsync());
        }

        private bool PaymentMethodExists(decimal id)
        {
            return _context.PaymentMethods.Any(e => e.VisaId == id);
        }

      
    }
}
