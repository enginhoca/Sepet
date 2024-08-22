using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.Entity.Abstract;

namespace BooksApp.Entity.Concrete
{
    public class Category : IBaseEntity, ICommonEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public DateTime ModifiedDate { get; set; }=DateTime.Now;
        public bool IsActive { get; set; }=true;
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsHome { get; set; }
        //Navigation Properties
        public List<BookCategory> BookCategories { get; set; }
    }
}