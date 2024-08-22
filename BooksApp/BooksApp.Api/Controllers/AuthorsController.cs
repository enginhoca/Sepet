using BooksApp.Service.Abstract;
using BooksApp.Shared.Helpers.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BooksApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IImageHelper _imageHelper;

        public AuthorsController(IAuthorService authorService, IImageHelper imageHelper)
        {
            _authorService=authorService;
            _imageHelper=imageHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _authorService.GetAllAsync();
            if (!response.IsSucceeded)
            {
                return NotFound(JsonSerializer.Serialize(response));
            }
            return Ok(JsonSerializer.Serialize(response));
        }
        [HttpPost("addimage")]
        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            var response = await _imageHelper.Upload(file, "authors");
            if (!response.IsSucceeded)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
