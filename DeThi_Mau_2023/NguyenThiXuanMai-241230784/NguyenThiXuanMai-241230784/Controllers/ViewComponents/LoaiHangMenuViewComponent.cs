using Microsoft.AspNetCore.Mvc;
using NguyenThiXuanMai_241230784.Models;
namespace NguyenThiXuanMai_241230784.Controllers.ViewComponents;
public class LoaiHangMenuViewComponent : ViewComponent  
{
    private readonly QlhangHoaContext _db;
    public LoaiHangMenuViewComponent(QlhangHoaContext context)
    {
        _db = context;
    }
    public IViewComponentResult Invoke()
    {   
        var danhsach = _db.LoaiHangs.ToList();
        return View(danhsach);
    }
}
