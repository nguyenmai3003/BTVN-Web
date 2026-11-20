using Microsoft.AspNetCore.Mvc;
using NguyenThiXuanMai_241230784.Models;

namespace NguyenThiXuanMai_241230784.Controllers
{
    public class SachController : Controller
    {
        private readonly QLNhaSachContext db;
        public SachController(QLNhaSachContext context)
        {
            db = context;
        }


        public IActionResult Index()
        {
            ViewBag.TieuDe = "Nguyễn Thị Xuân Mai";
            var danhSach = db.Sach
                .Where(s => s.Gia >=100)
                .ToList();
            return View(danhSach);
        }
    }
}
