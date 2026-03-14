using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BooksController: Controller
    {
        private readonly LibraryDbContext context = new LibraryDbContext();
        public ActionResult Index()
        {
            var books = context.Books.ToList();
            return View(books);
        }
    }
}