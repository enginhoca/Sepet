using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApp.Entity.Abstract
{
    //Projedeki BAZI entitylere implemente edilecek.
    public interface ICommonEntity
    {
        public string Name { get; set; }
    }
}