using Microsoft.AspNetCore.Mvc;
using SchoolProject.DAL;
using SchoolProject.Entities;

namespace SchoolProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly SchoolDBContext _context;

        public NewsController(SchoolDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Xeberler> News = _context.Xeberler.ToList();
            //return Json(News);
            return View(News);
        }
    }
}
