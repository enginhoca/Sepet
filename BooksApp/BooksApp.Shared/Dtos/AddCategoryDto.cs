using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApp.Shared.Dtos
{
    public class AddCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsHome { get; set; }
    }
}