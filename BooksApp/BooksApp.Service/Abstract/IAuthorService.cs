using BooksApp.Shared.Dtos;
using BooksApp.Shared.ResponseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Service.Abstract
{
    public interface IAuthorService
    {
        Task<Response<AuthorDto>> AddAsync(AuthorDto addAuthorDto);
        Task<Response<List<AuthorDto>>> GetAllAsync();
        Task<Response<AuthorDto>> GetByIdAsync(int id);
        Task<Response<AuthorDto>> UpdateAsync(AuthorDto editAuthorDto);
        Task<Response<NoContent>> DeleteAsync(int id);
    }
}
