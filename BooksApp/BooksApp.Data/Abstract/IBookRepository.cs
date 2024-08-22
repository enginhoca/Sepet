using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApp.Entity.Concrete;

namespace BooksApp.Data.Abstract
{
    public interface IBookRepository:IGenericRepository<Book>
    {
        Task<List<Book>> GetBooksWithCategoriesAsync();
        Task<Book> GetBookWithCategoriesAsync(int id);
        Task<List<Book>> GetBooksByCategoryIdAsync(int categoryId);
        Task<Book> CreateBookWithCategoriesAsync(Book book, List<int> categoryIds);
        //Task<Book> UpdateBookWithCategoriesAsync(Book book, List<int> categoryIds);
        Task ClearBookCategoriesAsync(int bookId);
        Task<List<Book>> GetActiveBooksAsync(bool isActive);
        Task<int> GetCount(int? categoryId=null);
        Task<List<Book>> GetHomeBooksAsync();
    }
}