using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        private readonly LibraryDbContext db = new LibraryDbContext();

        // =========================
        // STUDENTS
        // =========================

        public ActionResult Students()
        {
            var students = db.Students.ToList();
            return View(students);
        }

        public ActionResult EditStudent(int id)
        {
            var student = db.Students.Find(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            db.Entry(student).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Students");
        }

        public ActionResult DeleteStudent(int id)
        {
            var student = db.Students.Find(id);

            db.Students.Remove(student);
            db.SaveChanges();

            return RedirectToAction("Students");
        }

        // =========================
        // BOOKS
        // =========================

        public ActionResult Books()
        {
            var books = db.Books.ToList();
            return View(books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();

            return RedirectToAction("Books");
        }

        public ActionResult EditBook(int id)
        {
            var book = db.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            db.Entry(book).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Books");
        }

        public ActionResult DeleteBook(int id)
        {
            var book = db.Books.Find(id);

            db.Books.Remove(book);
            db.SaveChanges();

            return RedirectToAction("Books");
        }

        // =========================
        // BORROWS
        // =========================

        public ActionResult Borrows()
        {
            var borrows = db.Borrows
                .Include("Student")
                .Include("Book")
                .ToList();

            return View(borrows);
        }
    }
}