using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
namespace Manager.Controllers
{
    public class ProductController : Controller
    {
        MyDbContext _db;
        public ProductController(MyDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var product = _db.Products.ToList();
            return View(product);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IFormFile file, Product product)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName ="";
                if (file != null)
                {
                     uniqueFileName = await UploadFile(file);
                }

                product.LinkImage = uniqueFileName;
                product.ProductId = Guid.NewGuid();
                var a = deletefile("2.jpg");
                _db.Products.Add(product);
                _db.SaveChanges();

                //Employee employee = new Employee
                //{
                //    FirstName = model.FirstName,
                //    LastName = model.LastName,
                //    FullName = model.FirstName + " " + model.LastName,
                //    Gender = model.Gender,
                //    Age = model.Age,
                //    Office = model.Office,
                //    Position = model.Position,
                //    Salary = model.Salary,
                //    ProfilePicture = uniqueFileName,
                //};
                //dbContext.Add(employee);
                //await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        private async Task<string> UploadFile(IFormFile ufile)
        {
            if (ufile != null && ufile.Length > 0)
            {
                var fileName = Guid.NewGuid() + "-" + Path.GetFileName(ufile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ufile.CopyToAsync(fileStream);
                }
                return fileName;
            }
            return "";
        }
        public bool deletefile(string fname)
        {
            string _imageToBeDeleted =  Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fname);
            if ((System.IO.File.Exists(_imageToBeDeleted)))
            {
                System.IO.File.Delete(_imageToBeDeleted);
            }
            return true;
        }
    }
}
