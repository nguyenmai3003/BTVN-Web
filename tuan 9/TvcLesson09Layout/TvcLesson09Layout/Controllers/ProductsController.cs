using Microsoft.AspNetCore.Mvc;

namespace TvcLesson09Layout.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
