using BooksAppClient.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksAppClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
