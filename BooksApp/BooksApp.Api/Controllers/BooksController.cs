using System.Text.Json;
using BooksApp.Service.Abstract;
using BooksApp.Shared.Dtos;
using BooksApp.Shared.Helpers.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IImageHelper _imageHelper;

        public BooksController(IBookService bookService, IImageHelper imageHelper)
        {
            _bookService=bookService;
            _imageHelper=imageHelper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddBookDto addBookDto)
        {
            var response = await _bookService.AddAsync(addBookDto);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        // api/books
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _bookService.GetAllAsync();
            if(!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        // api/books
        [HttpGet("homebooks")]
        public async Task<IActionResult> GetHomeBooks()
        {
            var response = await _bookService.GetHomeBooksAsync();
            if(!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }        

        // api/books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _bookService.GetByIdAsync(id);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(EditBookDto editBookDto)
        {
            var response = await _bookService.UpdateAsync(editBookDto);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _bookService.DeleteAsync(id);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        // api/books/5
        [HttpGet("bycategory/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var response = await _bookService.GetBooksByCategoryIdAsync(categoryId);
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        // api/books/active/false
        [HttpGet("active/{isActive}")]
        public async Task<IActionResult> GetActiveBooks(bool isActive)
        {
            var response = await _bookService.GetActiveBooksAsync(isActive);
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }

        [HttpGet("getallbooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var response = await _bookService.GetBooksWithCategoriesAsync();
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }        

        [HttpPost("addimage")]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            var response = await _imageHelper.Upload(file,"books");
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
