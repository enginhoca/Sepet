using AutoMapper;
using BooksApp.Data.Abstract;
using BooksApp.Entity.Concrete;
using BooksApp.Service.Abstract;
using BooksApp.Shared.Dtos;
using BooksApp.Shared.ResponseDtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Service.Concrete
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository=bookRepository;
            _mapper=mapper;
        }

        public async Task<Response<BookDto>> AddAsync(AddBookDto addBookDto)
        {
            var book = _mapper.Map<Book>(addBookDto);
            
            var createdBook = await _bookRepository.CreateBookWithCategoriesAsync(book,addBookDto.CategoryIds);
            if (createdBook == null)
            {
                return Response<BookDto>.Fail("Bir sorun oluştu", 404);
            }
            var bookDto = _mapper.Map<BookDto>(createdBook);
            return Response<BookDto>.Success(bookDto, 201);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return Response<NoContent>.Fail("Böyle bir kitap bulunamadı", 404);
            }
            await _bookRepository.DeleteAsync(book);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<BookDto>>> GetActiveBooksAsync(bool isActive = true)
        {
            List<Book> books = await _bookRepository.GetActiveBooksAsync(isActive);
            if (books.Count==0)
            {
                return Response<List<BookDto>>.Fail("İstediğiniz kriterde kitap bulunamadı", 404);
            }
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            return Response<List<BookDto>>.Success(bookDtos, 200);
        }

        public async Task<Response<List<BookDto>>> GetAllAsync()
        {
            var books = await _bookRepository.GetBooksWithCategoriesAsync();
            if (books.Count==0)
            {
                return Response<List<BookDto>>.Fail("Hiç kitap bulunamadı", 404);
            }
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            return Response<List<BookDto>>.Success(bookDtos, 200);
        }

        public async Task<Response<List<BookDto>>> GetBooksByCategoryIdAsync(int categoryId)
        {
            var books = await _bookRepository.GetBooksByCategoryIdAsync(categoryId);
            if(books.Count==0)
            {
                return Response<List<BookDto>>.Fail("Bu kategoride hiç kitap bulunamadı", 404);
            }
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            return Response<List<BookDto>>.Success(bookDtos, 200);
        }

        public async Task<Response<List<BookDto>>> GetBooksWithCategoriesAsync()
        {
            var books = await _bookRepository.GetBooksWithCategoriesAsync();
            if (books.Count==0)
            {
                return Response<List<BookDto>>.Fail("Hiç kitap bulunamadı", 404);
            }
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            return Response<List<BookDto>>.Success(bookDtos, 200);
        }

        public async Task<Response<BookDto>> GetByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookWithCategoriesAsync(id);
            if (book == null)
            {
                return Response<BookDto>.Fail("Böyle bir kitap bulunamadı", 404);
            }
            var bookDto = _mapper.Map<BookDto>(book);
            return Response<BookDto>.Success(bookDto,200);
        }

        public async Task<Response<List<BookDto>>> GetHomeBooksAsync()
        {
            List<Book> books = await _bookRepository.GetHomeBooksAsync();
            if (books.Count==0)
            {
                return Response<List<BookDto>>.Fail("İstediğiniz kriterde kitap bulunamadı", StatusCodes.Status404NotFound);
            }
            var bookDtos = _mapper.Map<List<BookDto>>(books);
            return Response<List<BookDto>>.Success(bookDtos, StatusCodes.Status200OK);
        }

        public async Task<Response<BookDto>> UpdateAsync(EditBookDto editBookDto)
        {
            var book = _mapper.Map<Book>(editBookDto);//Dönüştürme
            if(book == null)
            {
                return Response<BookDto>.Fail("Bir hata oluştu", 400);
            }
            book.ModifiedDate=DateTime.Now;
            var updatedBook = await _bookRepository.UpdateAsync(book);
            await _bookRepository.ClearBookCategoriesAsync(updatedBook.Id);
            updatedBook.BookCategories=editBookDto
                .CategoryIds
                .Select(categoryId => new BookCategory
                {
                    BookId=updatedBook.Id,
                    CategoryId=categoryId
                }).ToList();
            await _bookRepository.UpdateAsync(updatedBook);
            var result = await _bookRepository.GetBookWithCategoriesAsync(updatedBook.Id);
            var bookDto = _mapper.Map<BookDto>(result);
            return Response<BookDto>.Success(bookDto,200);
        }
    }
}
