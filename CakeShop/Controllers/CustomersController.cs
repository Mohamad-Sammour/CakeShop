using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CakeShop.Model;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace CakeShop.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public CustomersController(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }

        // GET: Customers

       
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customers.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,Email,PhoneNumber,Image,Address ,ImageFile")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.ImageFile != null)
                {
                    string wwwroot = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" +customer.ImageFile.FileName;
                    string path = Path.Combine(wwwroot + "/Images/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await customer.ImageFile.CopyToAsync(fileStream); 
                    }
                    customer.Image = fileName;
                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("CustomerId,CustomerName,Email,PhoneNumber,Image,Address,ImageFile")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }
            //String id = "id"; ViewBag.sessionID = HttpContext.Session.GetInt32(id);
            //String name = "name"; ViewBag.sessionName = HttpContext.Session.GetString(name);

            if (ModelState.IsValid)
            {
                try
                {
                    if (customer.ImageFile != null)
                    {
                        string wwwroot = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + customer.ImageFile.FileName;
                        string path = Path.Combine(wwwroot + "/Images/" + fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await customer.ImageFile.CopyToAsync(fileStream);
                        }
                        customer.Image = fileName;
                        _context.Update(customer);
                        await _context.SaveChangesAsync();
                    }
                }


                
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> customerview()
        {
            return View(await _context.Customers.ToListAsync());
        }
        public async Task<IActionResult> customerviewA()
        {
            return View(await _context.Customers.ToListAsync());
        }

        private bool CustomerExists(decimal id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }




        public async Task<IActionResult> EditCusProfile(decimal? cid)
        {
            if (cid == null)
            {
                return NotFound();
            }
            String id = "id"; ViewBag.sessionID = HttpContext.Session.GetInt32(id);
            String name = "name"; ViewBag.sessionName = HttpContext.Session.GetString(name);

            var customer = await _context.Customers.FindAsync(cid);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCusProfile(decimal id, [Bind("CustomerId,CustomerName,Email,PhoneNumber,Image,Address,ImageFile")]Customer userLogin)
        {
            if (id != userLogin.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwwrootPath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + userLogin.ImageFile.FileName;
                    string path = Path.Combine(wwwwrootPath + "/Image/" + fileName);

                    using (var streamfile = new FileStream(path, FileMode.Create))
                    {
                        await userLogin.ImageFile.CopyToAsync(streamfile);
                    }

                    userLogin.Image = fileName;



                    _context.Update(userLogin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists( userLogin.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Homepage");
            }
            ViewData["RoleId"] = new SelectList("RoleId", "RoleId", userLogin.CustomerName);
            return View(userLogin);


        }
    }
}
