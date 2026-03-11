using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; } = string.Empty;

        public int Quantity { get; set; }

        public virtual ICollection<Borrow> Borrows { get; set; }
    }
}