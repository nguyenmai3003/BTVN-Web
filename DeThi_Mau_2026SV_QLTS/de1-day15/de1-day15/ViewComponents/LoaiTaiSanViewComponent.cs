using Microsoft.AspNetCore.Mvc;
using de1_day15.Models;

namespace de1_day15.ViewComponents;

public class LoaiTaiSanMenuViewComponent : ViewComponent
{
    private readonly QLTaiSanContext db;

    public LoaiTaiSanMenuViewComponent(QLTaiSanContext context)
    {
        db = context;
    }

    public IViewComponentResult Invoke()
    {
        var danhSach = db.LoaiTaiSan.ToList();
        return View(danhSach);
    }
}