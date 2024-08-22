using BooksApp.Shared.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Shared.Dtos;

namespace BooksApp.Service.Abstract
{
    public interface IBookService
    {
        Task<Response<BookDto>> AddAsync(AddBookDto addBookDto);
        Task<Response<List<BookDto>>> GetAllAsync();
        Task<Response<List<BookDto>>> GetBooksWithCategoriesAsync();
        Task<Response<List<BookDto>>> GetBooksByCategoryIdAsync(int categoryId);
        Task<Response<BookDto>> GetByIdAsync(int id);
        Task<Response<BookDto>> UpdateAsync(EditBookDto editBookDto);
        Task<Response<NoContent>> DeleteAsync(int id);
        Task<Response<List<BookDto>>> GetActiveBooksAsync(bool isActive = true);
        Task<Response<List<BookDto>>> GetHomeBooksAsync();
    }
}
