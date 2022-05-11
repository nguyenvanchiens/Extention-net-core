using Microsoft.AspNetCore.Mvc;

namespace Manager.Controllers
{
    public class CategoryController : Controller
    {
        MyDbContext _db;
        public CategoryController(MyDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var listcategory =  _db.Categories.ToList().Where(x=>x.ParentCategory==null);

            var qr = (from c in _db.Categories select c)
                .Include(c => c.ParentCategory)
                .Include(c => c.CategoryChildren);
            var categories = (qr.ToList().Where(c => c.ParentCategory == null));

            return View(listcategory);
        }
    }
}
