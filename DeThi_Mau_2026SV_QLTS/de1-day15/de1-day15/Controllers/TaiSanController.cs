using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using de1_day15.Models;

namespace de1_day15.Controllers;

public class TaiSanController : Controller
{
    private readonly QLTaiSanContext db;

    public TaiSanController(QLTaiSanContext context)
    {
        db = context;
    }

    public IActionResult Index()
    {
        ViewBag.TieuDe = "Nguyễn Thị Xuân Mai";
        var danhSach = db.TaiSan
            .Where(t => t.NguyenGia >= 20)
            .ToList();
        return View(danhSach);
    }

    public IActionResult RenderByID(int id)
    {
        var loaiTaiSan = db.LoaiTaiSan.Find(id);
        if (loaiTaiSan == null)
        {
            return NotFound();
        }

        ViewBag.TieuDe = loaiTaiSan.TenLoai;
        var danhSach = db.TaiSan
            .Where(t => t.MaLoai == id && t.NguyenGia != null)
            .ToList();
        return PartialView("de1_MainContent", danhSach);
    }
	public IActionResult Create()
	{
		ViewBag.MaLoai = new SelectList(
			db.LoaiTaiSan, "MaLoai", "TenLoai");

		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public IActionResult Create(TaiSan taiSan)
	{
		if (ModelState.IsValid)
		{
			db.TaiSan.Add(taiSan);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		ViewBag.MaLoai = new SelectList(
			db.LoaiTaiSan, "MaLoai", "TenLoai", taiSan.MaLoai);

		return View(taiSan);
	}
}