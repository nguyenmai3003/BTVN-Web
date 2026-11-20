using Microsoft.AspNetCore.Mvc;
using NguyenThiXuanMai_241230784.Models;
namespace NguyenThiXuanMai_241230784.ViewComponents
{
    public class TheLoaiMenuViewComponent : ViewComponent
    {
        private readonly QLNhaSachContext db;
        public TheLoaiMenuViewComponent(QLNhaSachContext context)
        {
            db = context;
        }
        public IViewComponentResult Invoke()
        {
            var theloai = db.TheLoai.ToList();
            return View(theloai);
        }
    }
}
