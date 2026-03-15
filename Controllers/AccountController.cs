using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly LibraryDbContext db = new LibraryDbContext();

        // GET Login
        public ActionResult Login()
        {
            return View();
        }

        // POST Login
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var user = db.Students
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // Lưu Session
                Session["User"] = user.Email;
                Session["Role"] = user.RoleId;
                Session["StudentId"] = user.Id;

                // Admin
                if (user.RoleId == 1)
                {
                    return RedirectToAction("Index", "Admin");
                }

                // Student
                return RedirectToAction("Index", "Books");
            }

            ViewBag.Error = "Sai email hoặc password";
            return View();
        }

        // GET Register
        public ActionResult Register()
        {
            return View();
        }

        // POST Register
        [HttpPost]
        public ActionResult Register(Student user)
        {
            if (ModelState.IsValid)
            {
                user.RoleId = 2;

                db.Students.Add(user);
                db.SaveChanges();

                return RedirectToAction("Login");
            }

            return View();
        }

        // Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
