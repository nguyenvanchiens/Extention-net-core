using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Manager.Controllers
{
    public class CategoryController : Controller
    {
        MyDbContext _db;
        public CategoryController(MyDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var listcategory =  _db.Categories.ToList().Where(x=>x.ParentCategory==null);

            var qr = (from c in _db.Categories select c)
                .Include(c => c.ParentCategory)
                .Include(c => c.CategoryChildren);
            var categories = (await qr.ToListAsync()).Where(c => c.ParentCategory == null).ToList();

            categories.Insert(0,new Category()
            {
                CategoryId = -1,
                CategoryName = "Không có danh mục cha"
            });
            var selectList = new SelectList(categories, "CategoryId", "CategoryName");

            return View(listcategory);
        }
        public async Task<IActionResult> Create()
        {
            var listcategory = _db.Categories.ToList().Where(x => x.ParentCategory == null);

            var qr = (from c in _db.Categories select c)
                .Include(c => c.ParentCategory)
                .Include(c => c.CategoryChildren);
            var categories = (await qr.ToListAsync()).Where(c => c.ParentCategory == null).ToList();

            categories.Insert(0, new Category()
            {
                CategoryId = -1,
                CategoryName = "Không có danh mục cha"
            });

            var items = new List<Category>();
            CreateSelectItems(categories, items, 0);
            var selectList = new SelectList(items, "CategoryId", "CategoryName");
            
            ViewData["ParentCategoryId"] = selectList;

            
            return View();
        }

        private void CreateSelectItems(List<Category> source, List<Category> des, int level)
        {
            string prefix = string.Concat(Enumerable.Repeat("--", level));
            foreach (var category in source)
            {
                category.CategoryName = prefix + category.CategoryName;
                des.Add(category);
                if (category.CategoryChildren?.Count > 0)
                {
                    CreateSelectItems(category.CategoryChildren.ToList(),des, level + 1);
                }
            }
        }
    }
}
