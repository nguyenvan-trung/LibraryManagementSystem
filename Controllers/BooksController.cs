using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryDbContext context = new LibraryDbContext();

        public ActionResult Index()
        {
            var books = context.Books.ToList();
            return View(books);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var book = context.Books.Find(id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        [HttpPost]
        public ActionResult BorrowBook(int bookId, DateTime returnDate)
        {
            int studentId = (int)Session["StudentId"];

            Borrow borrow = new Borrow
            {
                BookId = bookId,
                StudentId = studentId,
                BorrowDate = DateTime.Now,
                ReturnDate = returnDate,
                Status = "Borrowing"
            };

            context.Borrows.Add(borrow);
            context.SaveChanges();

            return RedirectToAction("Details", new { id = bookId });
        }
    }
}