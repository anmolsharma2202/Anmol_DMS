using DMSWebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DMSWebApp.Controllers
{
    public class LoginController : Controller
    {

        //private readonly ILogger<HomeController> _logger;
        private readonly IdentityModel db;

        public LoginController(ILogger<HomeController> logger, IdentityModel context)
        {
            //_logger = logger;
            db = context;

        }


        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login obj)
        {
            try
            {
                if (db.login.Any(a => a.Email == obj.Email && a.Password == obj.Password))
                {
                   TempData["user"] = obj.Email;
                     
                    return RedirectToAction("Index","Home");
                }

                else
                {
                    ViewBag.error = "!!Please Enter valid login credentials.";
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.error = "!!There is some error.";
            }
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(Login obj)
        {
            //db.login.Add(obj);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            try
            {
                if (ModelState.IsValid)
                {
                    db.login.Add(obj);
                    db.SaveChanges();
                    ViewBag.success = "Sign Up successfully.";

                    return RedirectToAction("Login");
 
                }
                else
                {
                    ViewBag.error = "!!There is some error.";
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ViewBag.error = "!!There is some error.";
            }
            return View();
        }

    }
}
