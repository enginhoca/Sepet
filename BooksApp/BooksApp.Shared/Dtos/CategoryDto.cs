using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApp.Shared.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsHome { get; set; }
        public int CountOfBooks { get; set; }
    }
}