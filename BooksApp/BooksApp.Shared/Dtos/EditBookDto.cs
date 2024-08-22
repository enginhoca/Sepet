using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Shared.Dtos
{
    public class EditBookDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Properties { get; set; }
        public string Summary { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int PageCount { get; set; }
        public int EditionYear { get; set; }
        public int EditionNumber { get; set; }
        public string ImageUrl { get; set; }
        public bool IsHome { get; set; }
        public List<int> CategoryIds { get; set; } = [];
    }
}
