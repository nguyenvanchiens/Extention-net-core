using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Controllers
{
    public class BaseController : Controller
    {
        protected MyDbContext _dbContext;
        public BaseController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
