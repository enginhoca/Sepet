using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.Entity.Abstract;

namespace BooksApp.Entity.Concrete
{
    public class Book : IBaseEntity, ICommonEntity
    {    
        //IBase
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public DateTime ModifiedDate { get; set; }=DateTime.Now;
        public bool IsActive { get; set; }
        //ICommon
        public string Name { get; set; }
        //Book
        public string Properties { get; set; }
        public string Summary { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int PageCount { get; set; }
        public int EditionYear { get; set; }
        public int EditionNumber { get; set; } = 1;
        public string ImageUrl { get; set; }
        public bool IsHome { get; set; }
        //Navigation Properties
        public List<BookCategory> BookCategories { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}