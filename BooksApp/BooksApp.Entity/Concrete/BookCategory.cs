using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApp.Entity.Concrete
{
    public class BookCategory
    {
        public int BookId { get; set; }
        public Book Book { get; set; }//Navigation property
        public int CategoryId { get; set; }
        public Category Category { get; set; }//Navigation property
    }
}