using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentsController : Controller
    {
        private readonly LibraryDbContext db = new LibraryDbContext();

        // My Profile
        public ActionResult MyProfile()
        {
            if (Session["StudentId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int id = Convert.ToInt32(Session["StudentId"]);

            var student = db.Students.Find(id);

            return View(student);
        }

        // Edit Profile
        public ActionResult EditProfile()
        {
            if (Session["StudentId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int id = Convert.ToInt32(Session["StudentId"]);

            var student = db.Students.Find(id);

            return View(student);
        }

        // Update Profile
        [HttpPost]
        public ActionResult EditProfile(Student model)
        {
            var student = db.Students.Find(model.Id);

            if (student != null)
            {
                // Chỉ cho sửa Name
                student.Name = model.Name;

                db.SaveChanges();
            }

            return RedirectToAction("MyProfile");
        }
    }
}