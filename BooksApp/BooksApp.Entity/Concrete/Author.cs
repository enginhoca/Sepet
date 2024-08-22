using BooksApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Entity.Concrete
{
    public class Author : IBaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public DateTime ModifiedDate { get; set; }=DateTime.Now;
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string PhotoUrl { get; set; }
        public List<Book> Books { get; set; }
    }
}
