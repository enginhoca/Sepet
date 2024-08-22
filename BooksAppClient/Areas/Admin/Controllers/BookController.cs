using BooksAppClient.Areas.Admin.Models;
using BooksAppClient.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace BooksAppClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var rootBooks = new Root<List<BookModel>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/books/getallbooks"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootBooks = System.Text.Json.JsonSerializer.Deserialize<Root<List<BookModel>>>(contentResponse);
                }
            }
            return View(rootBooks.Data);
        }
    
        public async Task<IActionResult> Create()
        {
            //Category listesi çekme kısmı başlangıcı
            var rootCategories = new Root<List<CategoryModel>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/categories"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootCategories = System.Text.Json.JsonSerializer.Deserialize<Root<List<CategoryModel>>>(contentResponse);
                }
            }
            //Category listesi çekme kısmı bitiş

            //Author listesi çekme kısmı başlangıcı
            var rootAuthors = new Root<List<AuthorModel>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/authors"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootAuthors = System.Text.Json.JsonSerializer.Deserialize<Root<List<AuthorModel>>>(contentResponse);
                }
            }
            //Author listesi çekme kısmı bitiş

            AddBookModel bookModel = new AddBookModel
            {
                CategoryList= rootCategories.Data,
                AuthorList= rootAuthors
                    .Data
                    .Select(x => new SelectListItem {
                        Text=x.FirstName + " " + x.LastName,
                        Value=x.Id.ToString()
                    }).ToList()
            };
            return View(bookModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddBookModel addBookModel, IFormFile image)
        {
            if (ModelState.IsValid && addBookModel.CategoryIds!=null && image!=null)
            {
                using (var httpClient = new HttpClient())
                {
                    var imageUrl="";
                    //Resim yükleme/ekleme
                    using (var stream = image.OpenReadStream())
                    {
                        var imageContent = new MultipartFormDataContent();
                        byte[] bytes = stream.ToByteArray();
                        imageContent.Add(new ByteArrayContent(bytes), "file", image.FileName);
                        HttpResponseMessage responseMessage = await httpClient.PostAsync("http://localhost:5500/api/books/addimage", imageContent);
                        var responseString= await responseMessage.Content.ReadAsStringAsync();
                        //var response = JsonSerializer.Deserialize<Root<ImageModel>>(responseString);
                        var response = JsonConvert.DeserializeObject<Root<ImageModel>>(responseString);
                        if(response.IsSucceeded)
                        {
                            imageUrl = response.Data.ImageUrl;
                        }
                        else
                        {
                            Console.Write(response.Error);
                        }
                        
                    }
                    addBookModel.ImageUrl=imageUrl;
                    //Kitap ekleme
                    var serializeModel = System.Text.Json.JsonSerializer.Serialize(addBookModel);
                    var stringContent = new StringContent(serializeModel,Encoding.UTF8,"application/json");
                    var result = await httpClient.PostAsync("http://localhost:5500/api/Books", stringContent);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            //Category listesi çekme kısmı başlangıcı
            var rootCategories = new Root<List<CategoryModel>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/categories"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootCategories = System.Text.Json.JsonSerializer.Deserialize<Root<List<CategoryModel>>>(contentResponse);
                }
            }
            //Category listesi çekme kısmı bitiş

            //Author listesi çekme kısmı başlangıcı
            var rootAuthors = new Root<List<AuthorModel>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/authors"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootAuthors = System.Text.Json.JsonSerializer.Deserialize<Root<List<AuthorModel>>>(contentResponse);
                }
            }
            //Author listesi çekme kısmı bitiş
            addBookModel.CategoryList=rootCategories.Data;
            addBookModel.AuthorList=rootAuthors
                    .Data
                    .Select(x => new SelectListItem
                    {
                        Text=x.FirstName + " " + x.LastName,
                        Value=x.Id.ToString()
                    }).ToList();
            ViewBag.CategoryErrorMessage=addBookModel.CategoryIds==null? "En az bir kategori seçilmelidir":null;
            ViewBag.ImageErrorMessage=image==null ? "Resim seçiniz" : null;
            return View(addBookModel);
        }
    }
}
