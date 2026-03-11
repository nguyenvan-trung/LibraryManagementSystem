using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Borrow
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int BookId { get; set; }

        public DateTime BorrowDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public string Status { get; set; }

        public virtual Student Student { get; set; }

        public virtual Book Book { get; set; }
    }
}