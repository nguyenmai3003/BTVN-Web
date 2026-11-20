using Microsoft.AspNetCore.Mvc;
using NguyenThiXuanMai_241230784.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult RenderByID(int id)
        {
            var theloai = db.TheLoai.Find(id);
            if( theloai == null)
            {
                return NotFound();  
            }
            ViewBag.TieuDe = theloai.TenTL;
            var danhsach= db.Sach
            .Where ( s => s.MaTL == id && s.Gia !=null)
            .ToList();
            
            return PartialView("Nguyễn Thị Xuân Mai_MainContent", danhsach);
        }
        public IActionResult Create()
        {
            ViewBag.MaTL = new SelectList(db.TheLoai, "MaTL", "TenTL");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Sach.Add(sach);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.MaTL = new SelectList(
                db.TheLoai, "MaTL", "TenTL", sach.MaTL);

            return View(sach);
        }
    }
}
