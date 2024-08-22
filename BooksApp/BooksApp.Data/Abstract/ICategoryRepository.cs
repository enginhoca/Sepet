using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.Entity.Concrete;

namespace BooksApp.Data.Abstract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        //Tüm entity'ler için ihtiyaç olan metotlar zaten IGenericRepository'den Category'e göre uyarlanarak buraya geliyor.
        //Buna ek olarak, burada Category entitysi için ihtiyaç duyduğumuz metotları yazabiliriz.
        Task<List<Category>> GetActiveCategoriesAsync();
        Task<List<Category>> GetHomeCategoriesAsync();

    }
}