using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BooksAppClient.Models;
using BooksAppClient.Repository;
using System.Text.Json;

namespace BooksAppClient.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        //Anasayfa Kategorilerini Api'dan iste!
        var rootCategories = new Root<List<CategoryViewModel>>();
        using (var httpClient = new HttpClient())
        {
            using (HttpResponseMessage httpResponseMessage= await httpClient.GetAsync("http://localhost:5500/api/Categories/home"))
            {
                if(!httpResponseMessage.IsSuccessStatusCode)
                {
                    return null;
                }
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                rootCategories = JsonSerializer.Deserialize<Root<List<CategoryViewModel>>>(contentResponse);
            }
        }

        //Anasayfa Kitaplarýný Api'den iste
        var rootBooks = new Root<List<BookViewModel>>();
        using (var httpClient = new HttpClient())
        {
            using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:5500/api/Books/homebooks"))
            {
                if(!httpResponseMessage.IsSuccessStatusCode)
                {
                    return null;
                }
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                rootBooks = JsonSerializer.Deserialize<Root<List<BookViewModel>>>(contentResponse);
            }
        }
        var homePageModel = new HomePageModel
        {
            Categories=rootCategories.Data,
            Books=rootBooks.Data
        };
        return View(homePageModel);
    }
}
