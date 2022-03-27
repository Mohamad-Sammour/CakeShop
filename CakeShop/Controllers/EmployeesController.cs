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
    public class EmployeesController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public EmployeesController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


     

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            String id = "id"; ViewBag.sessionID = HttpContext.Session.GetInt32(id);
            String name = "name"; ViewBag.sessionName = HttpContext.Session.GetString(name);
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Fullname,Email,Password,PhoneNumber,HairedDate,Salary,Image,Roleid,ImageFile")] Employee employee, string password)
        {
            if (ModelState.IsValid)
            {
                if (employee.ImageFile != null)
                {
                    string wwwroot = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + employee.ImageFile.FileName;
                    string path = Path.Combine(wwwroot + "/Images/" + fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await employee.ImageFile.CopyToAsync(fileStream);
                    }
                    employee.Image = fileName;
                    _context.Add(employee);
                    await _context.SaveChangesAsync();

                    //login
                    Login login = new Login();
                    login.Email = employee.Email;
                    login.Password = password;
                    login.EmployeeId = employee.EmployeeId;
                    login.RoleId = 2;

                    _context.Add(login);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Employees");
                }

            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //String id = "id"; ViewBag.sessionID = HttpContext.Session.GetInt32(id);
            //String name = "name"; ViewBag.sessionName = HttpContext.Session.GetString(name);
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("EmployeeId,Fullname,Email,Password,PhoneNumber,HairedDate,Salary,Image,Roleid,ImageFile")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (employee.ImageFile != null)
                    {
                        string wwwroot = _webHostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + employee.ImageFile.FileName;
                        string path = Path.Combine(wwwroot + "/Images/" + fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await employee.ImageFile.CopyToAsync(fileStream);
                        }
                        employee.Image = fileName;
                        _context.Update(employee);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(decimal id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }

        public async Task<IActionResult> EditAdminAsync(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //String id = "id"; ViewBag.sessionID = HttpContext.Session.GetInt32(id);
            //String name = "name"; ViewBag.sessionName = HttpContext.Session.GetString(name);
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> EAdmin(decimal? id, [Bind("EmployeeId,Fullname,Email,Password,PhoneNumber,HairedDate,Salary,Image,Roleid,ImageFile")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }
            //String id = "id"; ViewBag.sessionID = HttpContext.Session.GetInt32(id);
            //String name = "name"; ViewBag.sessionName = HttpContext.Session.GetString(name);

            if (ModelState.IsValid)
            {
                try
                {
                    if (employee.ImageFile != null)
                    {
                        string wwwroot = _webHostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + employee.ImageFile.FileName;
                        string path = Path.Combine(wwwroot + "/Images/" + fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await employee.ImageFile.CopyToAsync(fileStream);
                        }
                        employee.Image = fileName;
                        _context.Update(employee);
                        await _context.SaveChangesAsync();
                    }
                }



                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            return View(employee);
        }
      
        public async Task<IActionResult> EditAccountant(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //String id = "id"; ViewBag.sessionID = HttpContext.Session.GetInt32(id);
            //String name = "name"; ViewBag.sessionName = HttpContext.Session.GetString(name);
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAccountant(decimal id, [Bind("EmployeeId,Fullname,Email,Password,PhoneNumber,HairedDate,Salary,Image,Roleid,ImageFile")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (employee.ImageFile != null)
                    {
                        string wwwroot = _webHostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + employee.ImageFile.FileName;
                        string path = Path.Combine(wwwroot + "/Images/" + fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await employee.ImageFile.CopyToAsync(fileStream);
                        }
                        employee.Image = fileName;
                        _context.Update(employee);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            return View(employee);
        }

       

    }
}
