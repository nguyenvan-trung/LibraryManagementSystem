using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BorrowsController : Controller
    {
        private readonly LibraryDbContext context = new LibraryDbContext();
        public ActionResult MyBooks()
        {
            if (Session["StudentId"] == null)
                return RedirectToAction("Login", "Account");

            int studentId = (int)Session["StudentId"];

            var students = context.Borrows
                .Where(b => b.StudentId == studentId)
                .ToList();

            return View(students);
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}