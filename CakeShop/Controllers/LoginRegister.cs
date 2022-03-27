using CakeShop.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Controllers
{
    public class LoginRegister : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public LoginRegister(ModelContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("CustomerId,CustomerName,Email,PhoneNumber,Image,Address ,ImageFile")] Customer customer, string password)
        {
            if (ModelState.IsValid)
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
                    _context.Add(customer);
                    await _context.SaveChangesAsync();


                    //login
                    Login login = new Login();
                    login.Email = customer.Email;
                    login.Password = password;
                    login.CustomerId = customer.CustomerId;
                    login.RoleId = 3;

                    _context.Add(login);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string password)
        {
            var Auth = _context.Logins.Where(x => x.Email == Email && x.Password == password).SingleOrDefault();
            var x = _context.Logins.Where(x => x.Email == Email && x.Password == password).Select(x => x.LoginId).SingleOrDefault();
            var y = _context.Logins.Where(x => x.Email == Email && x.Password == password).Select(x => x.Email).SingleOrDefault();
            //var z = _context.Logins.Where(x => x.Email == Email && x.Password == password).Select(x => x.Employee.EmployeeId).SingleOrDefault();
            //var m = _context.Logins.Where(x => x.Email == Email && x.Password == password).Select(x => x.Employee.Fullname).SingleOrDefault();
            
            //const String  Eid = "Eid";
            //const  String Ename = "Ename";
            const String  id = "id";
            const String  name = "name";
            if (Auth != null)
            {
                switch (Auth.RoleId)
                {

                   
                    case 1:
                        {
                            x = Convert.ToInt32(x);
                            HttpContext.Session.SetInt32(id, (int)x);
                            HttpContext.Session.SetString(name, y);
                            return RedirectToAction("Index", "Employees");
                        }

                    case 2:
                        {
                            x = Convert.ToInt32(x);
                            HttpContext.Session.SetInt32(id, (int)x);
                            HttpContext.Session.SetString(name, y);
                            return RedirectToAction("ForAccountant", "PaymentMethods");
                        }
                    case 3:
                        {
                            x = Convert.ToInt32(x);
                            HttpContext.Session.SetInt32(id, (int)x);
                            HttpContext.Session.SetString(name, y);
                            return RedirectToAction("Home", "Home");
                        }
                }
            }
            return View();
        }

    }
}
