using Microsoft.AspNetCore.Mvc;
using SchoolProject.DAL;
using SchoolProject.Entities;

namespace SchoolProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly SchoolDBContext _context;
        public StudentController(SchoolDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Telebeler> telebeler = _context.Telebeler.ToList();
            return View(telebeler);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Telebeler telebe)
        {
            if (telebe is null) return BadRequest();

            _context.Telebeler.Add(telebe);
            _context.SaveChanges();
            return View(telebe);
        }
    }
}
