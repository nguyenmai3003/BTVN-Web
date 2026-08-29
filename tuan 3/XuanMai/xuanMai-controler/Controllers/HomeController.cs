using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using xuanMai_controler.Models;

namespace xuanMai_controler.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "class CNTT2-K65";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
